using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Common;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Result<ProductViewModel>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<ProductViewModel>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.CompleteAsync();

            var stockProduct = new StockProduct(product.Id, product.QuantityInStock);
            stockProduct.SetCreatedByUserId(product.CreatedByUserId);

            await _unitOfWork.StockProducts.AddAsync(stockProduct);
            await _unitOfWork.CompleteAsync();

            var viewModel = _mapper.Map<ProductViewModel>(product);
            return Result<ProductViewModel>.Success(viewModel);
        }
    }
}
