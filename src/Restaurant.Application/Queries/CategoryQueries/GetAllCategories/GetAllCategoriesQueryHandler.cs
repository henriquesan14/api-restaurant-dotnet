using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Application.ViewModels.Page;
using Restaurant.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Queries.CategoryQueries.GetByCategoryType
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, PagedListViewModel<CategoryViewModel>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<PagedListViewModel<CategoryViewModel>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetAllAsync(request.PageFilter.PageSize, request.PageFilter.PageNumber, request.CategoryType, request.Name);
            var viewModel = _mapper.Map<List<CategoryViewModel>>(result);
            return new PagedListViewModel<CategoryViewModel>(viewModel, viewModel.Count(), request.PageFilter.PageNumber, request.PageFilter.PageSize);
        }
    }
}
