using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Application.ViewModels.Page;
using Restaurant.Core.Entities;
using Restaurant.Core.Enums;
using Restaurant.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Queries.OrderQueries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, PagedListViewModel<OrderViewModel>>
    {
        private readonly IOrderRepository _orderRepository;
        private IMapper _mapper;

        public GetAllOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<PagedListViewModel<OrderViewModel>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyCollection<Order> orders = null;
            if (request.OrderType == OrderType.COMMON)
            {
                orders = await _orderRepository.GetAllCommonOrdersAsync(request.PageFilter.PageSize, request.PageFilter.PageNumber);
            }
            else
            {
                orders = await _orderRepository.GetAllDeliveryOrdersAsync(request.PageFilter.PageSize, request.PageFilter.PageNumber);
            }

            var ordersViewModel = _mapper.Map<List<OrderViewModel>>(orders);
            return new PagedListViewModel<OrderViewModel>(ordersViewModel, ordersViewModel.Count(), request.PageFilter.PageNumber, request.PageFilter.PageSize);

        }
    }
}
