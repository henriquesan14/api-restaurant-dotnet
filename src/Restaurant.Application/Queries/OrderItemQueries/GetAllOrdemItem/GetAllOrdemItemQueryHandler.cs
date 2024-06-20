using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Application.ViewModels.Page;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using System.Linq.Expressions;

namespace Restaurant.Application.Queries.OrderItemQueries.GetAllOrdemItem
{
    public class GetAllOrdemItemQueryHandler : IRequestHandler<GetAllOrdemItemQuery, PagedListViewModel<OrderItemViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllOrdemItemQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedListViewModel<OrderItemViewModel>> Handle(GetAllOrdemItemQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<OrderItem, bool>> predicate = p =>
                (p.Status.Equals(request.Status) || !request.Status.HasValue) &&
                (p.CreatedAt == request.Date || request.Date == null);
                

            var result = await _unitOfWork.OrderItems.GetAsync(predicate, pageNumber: request.PageNumber, pageSize: request.PageSize);
            var count = await _unitOfWork.OrderItems.GetCountAsync(predicate);
            var orderItemsViewModel = _mapper.Map<List<OrderItemViewModel>>(result);
            return new PagedListViewModel<OrderItemViewModel>(orderItemsViewModel, count, request.PageNumber, request.PageSize);
        }
    }
}
