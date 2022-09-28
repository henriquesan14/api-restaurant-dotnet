using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Application.ViewModels.Page;
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
            var orders = await _orderRepository.GetAllAsync(request.PageFilter.PageSize, request.PageFilter.PageNumber);
            var ordersViewModel = _mapper.Map<List<OrderViewModel>>(orders);
            return new PagedListViewModel<OrderViewModel>(ordersViewModel, ordersViewModel.Count(), request.PageFilter.PageNumber, request.PageFilter.PageSize);
        }
    }
}
