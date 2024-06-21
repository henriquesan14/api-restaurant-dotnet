using AutoMapper;
using MediatR;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Commands.ProductCommands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request);
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.CompleteAsync();
            return product.Id;
        }
    }
}
