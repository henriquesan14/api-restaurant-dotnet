using AutoMapper;
using MediatR;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System;

namespace Restaurant.Application.Commands.OrderCommands.CreateDeliveryOrder
{
    public class CreateDeliveryOrderCommandHandler : IRequestHandler<CreateDeliveryOrderCommand, int>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public CreateDeliveryOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<int> Handle(CreateDeliveryOrderCommand request, CancellationToken cancellationToken)
        {
            // TODO: implementar lógica de autorização
            var entity = _mapper.Map<DeliveryOrder>(request);
            decimal valueTotal = 0;
            entity.Status = Core.Enums.OrderStatusEnum.CREATED;
            entity.Type = "Delivery";
            entity.ValueTotal = entity.Items.Sum(i => i.SubTotal);
            entity.Items.ToList().ForEach(async i =>
            {
                i.Status = Core.Enums.OrderItemStatusEnum.PENDING;
                i.CreatedAt = DateTime.Now;
                var product = await _productRepository.GetByIdAsync(i.ProductId);
                valueTotal += product.Price * i.Quantity;
            });
            entity.ValueTotal = valueTotal;

            var result = await _orderRepository.AddAsync(entity);
            return result.Id;
        }
    }
}
