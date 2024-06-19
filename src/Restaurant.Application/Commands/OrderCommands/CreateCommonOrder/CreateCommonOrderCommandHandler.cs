using AutoMapper;
using MediatR;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Commands.OrderCommands.CreateCommonOrder
{
    public class CreateCommonOrderCommandHandler : IRequestHandler<CreateCommonOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateCommonOrderCommandHandler(IOrderRepository orderRepository, ITableRepository tableRepository, IMapper mapper, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _tableRepository = tableRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<int> Handle(CreateCommonOrderCommand request, CancellationToken cancellationToken)
        {
            // TODO: implementar lógica de autorização
            var entity = _mapper.Map<CommonOrder>(request);
            decimal valueTotal = 0; 
            entity.Status = Core.Enums.OrderStatusEnum.CREATED;
            entity.EmployeeId = request.EmployeeId;
            entity.Type = "Common";

            entity.Items.ToList().ForEach(async i =>
            {
                i.Status = Core.Enums.OrderItemStatusEnum.PENDING;
                i.CreatedAt = DateTime.Now;
                var product = await _productRepository.GetByIdAsync(i.ProductId);
                valueTotal += product.Price * i.Quantity;
            });
            entity.ValueTotal = valueTotal;

            await _tableRepository.UpdateStatusAsync(entity.TableId, Core.Enums.TableStatusEnum.BUSY);
            var result = await _orderRepository.AddAsync(entity);
            return result.Id;
        }
    }
}
