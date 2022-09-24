using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Application.ViewModels.Page;
using Restaurant.Core.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Queries.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, PagedListViewModel<ProductViewModel>>
    {


        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetAllProductsQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PagedListViewModel<ProductViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _repository.GetAllAsync(request.PageFilter.PageSize, request.PageFilter.PageNumber, request.PageFilter.FilterName);
            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);
            return new PagedListViewModel<ProductViewModel>(productsViewModel, productsViewModel.Count(), request.PageFilter.PageNumber, request.PageFilter.PageSize);
        }
    }
}
