using AutoMapper;
using MediatR;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Commands.ProductCommands.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(request.Id);
            if (product == null)
            {
                return 0;
            }
            var productUpdate = _mapper.Map(request, product);
            _unitOfWork.Products.UpdateAsync(productUpdate);
            await _unitOfWork.CompleteAsync();
            return product.Id;
        }
    }
}
