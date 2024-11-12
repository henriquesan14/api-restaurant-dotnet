using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Application.ViewModels.Page;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using System.Linq.Expressions;

namespace Restaurant.Application.Queries.CategoryQueries.GetByCategoryType
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, PagedListViewModel<CategoryViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PagedListViewModel<CategoryViewModel>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<ProductCategory, bool>> predicate = p => (request.Name == null || p.Name.ToLower().Contains(request.Name.ToLower()));
           
            var list = await _unitOfWork.Categories.GetAsync(predicate, pageNumber: request.PageNumber, pageSize: request.PageSize);
            var count = await _unitOfWork.Categories.GetCountAsync(predicate);
            var viewModel = _mapper.Map<List<CategoryViewModel>>(list);
            return new PagedListViewModel<CategoryViewModel>(viewModel, count, request.PageNumber, request.PageSize);
        }
    }
}
