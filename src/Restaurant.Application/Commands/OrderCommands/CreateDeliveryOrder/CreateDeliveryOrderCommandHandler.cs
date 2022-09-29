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
        private readonly IMapper _mapper;

        public CreateDeliveryOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateDeliveryOrderCommand request, CancellationToken cancellationToken)
        {
            // TODO: implementar lógica de autorização
            var entity = _mapper.Map<DeliveryOrder>(request);
            entity.Status = Core.Enums.OrderStatus.PENDING;
            entity.Type = "Delivery";
            entity.Items.ToList().ForEach(i =>
            {
                i.Status = Core.Enums.ItemOrderStatus.PENDING;
                i.CreatedAt = DateTime.Now;
            });

            var result = await _orderRepository.AddAsync(entity);
            return result.Id;
        }
    }
}
