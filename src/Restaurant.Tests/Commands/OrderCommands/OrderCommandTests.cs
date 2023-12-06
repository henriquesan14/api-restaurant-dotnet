using AutoMapper;
using Moq;
using Restaurant.Application.Commands.OrderCommands;
using Restaurant.Application.Commands.OrderCommands.CreateCommonOrder;
using Restaurant.Application.Mappers;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using Xunit;

namespace Restaurant.Tests.Commands.OrderCommands
{

    public class OrderCommandTests
    {
        private Mock<IOrderRepository> _mockOrderRepository;
        private Mock<ITableRepository> _mockTableRepository;
        private IMapper _mapper;
        private Mock<IProductRepository> _mockProductRepository;

        public OrderCommandTests()
        {
            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockProductRepository = new Mock<IProductRepository>();
            _mockTableRepository = new Mock<ITableRepository>();
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new OrderMapper());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
        }

        [Fact]
        public async Task CreateOrder_Executed_ReturnOrderViewModel()
        {
            // Arrange
            var items = new List<OrderItemCommand>() {
                new OrderItemCommand
                {
                   ProductId = 1,
                   Quantity = 1, 
                }
            };
            var createCommonOrderCommand = new CreateCommonOrderCommand
            {
                Items = items,
                ClientId = 1,
                EmployeeId = 1,
                TableId = 1
            };

            _mockProductRepository.Setup(pr => pr.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(It.IsAny<Product>());
            _mockOrderRepository.Setup(or => or.AddAsync(It.IsAny<Order>())).ReturnsAsync(It.IsAny<Order>());

            //Act

            var command = new CreateCommonOrderCommandHandler(_mockOrderRepository.Object, _mockTableRepository.Object, _mapper, _mockProductRepository.Object);
            var result = await command.Handle(createCommonOrderCommand, new CancellationToken());

            // Assert

            Assert.NotEqual(0, result);
            _mockProductRepository.Verify(pr => pr.GetByIdAsync(It.IsAny<int>()), Times.Exactly(items.Count));
            _mockOrderRepository.Verify(or => or.AddAsync(It.IsAny<Order>()), Times.Once);

        }
    }
}
