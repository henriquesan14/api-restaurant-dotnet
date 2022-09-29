using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Queries.OrderQueries.GetOrder
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, OrderViewModel>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<OrderViewModel> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            Order order;
            if (request.OrderType == Core.Enums.OrderType.COMMON)
            {
                order = await _orderRepository.GetCommonOrderByIdAsync(request.Id);
                return _mapper.Map<OrderViewModel>(order);
            }
            order = await _orderRepository.GetDeliveryOrderByIdAsync(request.Id);
            return _mapper.Map<OrderViewModel>(order);

        }
    }
}
