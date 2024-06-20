using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Application.ViewModels.Page;
using Restaurant.Core.Entities;
using Restaurant.Core.Enums;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Queries.OrderQueries.GetAllOrders
{
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, PagedListViewModel<OrderViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public GetAllOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedListViewModel<OrderViewModel>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            IReadOnlyCollection<Order> orders;
            int count;
            if (request.OrderType == OrderTypeEnum.COMMON)
            {
                orders = await _unitOfWork.Orders.GetAllCommonOrdersAsync(request.PageSize, request.PageNumber, request.Status, request.Date);
                count = await _unitOfWork.Orders.GetCountCommonOrdersAsync(request.Status, request.Date);
            }
            else
            {
                orders = await _unitOfWork.Orders.GetAllDeliveryOrdersAsync(request.PageSize, request.PageNumber, request.Status, request.Date);
                count = await _unitOfWork.Orders.GetCountCommonOrdersAsync(request.Status, request.Date);
            }

            var ordersViewModel = _mapper.Map<List<OrderViewModel>>(orders);
            return new PagedListViewModel<OrderViewModel>(ordersViewModel, count, request.PageNumber, request.PageSize);

        }
    }
}
