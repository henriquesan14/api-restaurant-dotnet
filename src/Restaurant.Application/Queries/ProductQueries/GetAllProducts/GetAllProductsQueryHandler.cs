using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Application.ViewModels.Page;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Queries.ProductQueries.GetAllProducts
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


            var products = await _repository.GetAllAsync();
            var count = await _repository.GetCountAsync();
            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);
            return new PagedListViewModel<ProductViewModel>(productsViewModel, count, request.PageNumber, request.PageSize);
        }
    }
}
