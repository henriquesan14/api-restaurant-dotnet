using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Application.ViewModels.Page;
using Restaurant.Core.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Queries.OrderQueries.GetAllOrdersByClient
{
    public class GetOrdersByClientQueryHandler : IRequestHandler<GetOrdersByClientQuery, PagedListViewModel<OrderViewModel>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersByClientQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<PagedListViewModel<OrderViewModel>> Handle(GetOrdersByClientQuery request, CancellationToken cancellationToken)
        {
            var result = await _orderRepository.GetOrdersByClient(request.PageFilter.PageSize, request.PageFilter.PageNumber, request.ClientId);
            var viewModel = _mapper.Map<List<OrderViewModel>>(result);
            return new PagedListViewModel<OrderViewModel>(viewModel, viewModel.Count, request.PageFilter.PageNumber, request.PageFilter.PageSize);
        }
    }
}
