using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Application.ViewModels.Page;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using System.Linq.Expressions;

namespace Restaurant.Application.Queries.OrderQueries.GetAllOrdersByClient
{
    public class GetOrdersByClientQueryHandler : IRequestHandler<GetOrdersByClientQuery, PagedListViewModel<OrderViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOrdersByClientQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedListViewModel<OrderViewModel>> Handle(GetOrdersByClientQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Order, bool>> predicate = o =>
                (o.ClientId == request.ClientId);
                
            var result = await _unitOfWork.Orders.GetAsync(predicate, pageNumber: request.PageNumber, pageSize: request.ClientId);
            var count  = await _unitOfWork.Orders.GetCountAsync(predicate);
            var viewModel = _mapper.Map<List<OrderViewModel>>(result);
            return new PagedListViewModel<OrderViewModel>(viewModel, count, request.PageNumber, request.PageSize);
        }
    }
}
