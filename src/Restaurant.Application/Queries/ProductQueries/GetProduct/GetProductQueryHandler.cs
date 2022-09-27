using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Queries.ProductQueries.GetProduct
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, ProductViewModel>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public GetProductQueryHandler(IProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductViewModel> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<ProductViewModel>(product);
        }
    }
}
