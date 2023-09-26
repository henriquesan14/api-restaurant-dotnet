using MediatR;
using Restaurant.Application.ViewModels.Page;
using Restaurant.Application.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using Restaurant.Core.Repositories;
using AutoMapper;
using System.Linq;

namespace Restaurant.Application.Queries.OrderItemQueries.GetAllOrdemItem
{
    public class GetAllOrdemItemQueryHandler : IRequestHandler<GetAllOrdemItemQuery, PagedListViewModel<OrderItemViewModel>>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public GetAllOrdemItemQueryHandler(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<PagedListViewModel<OrderItemViewModel>> Handle(GetAllOrdemItemQuery request, CancellationToken cancellationToken)
        {
            var result = await _orderItemRepository.GetAllOrderItems(request.PageFilter.PageSize, request.PageFilter.PageNumber, request.Status, request.Date);
            var orderItemsViewModel = _mapper.Map<List<OrderItemViewModel>>(result);
            return new PagedListViewModel<OrderItemViewModel>(orderItemsViewModel, orderItemsViewModel.Count(), request.PageFilter.PageNumber, request.PageFilter.PageSize);
        }
    }
}
