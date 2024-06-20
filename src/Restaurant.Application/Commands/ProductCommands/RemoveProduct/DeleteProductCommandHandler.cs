using MediatR;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Commands.ProductCommands.RemoveProduct
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(request.Id);
            if(product == null)
            {
                return 0;
            }
            _unitOfWork.Products.DeleteAsync(product);
            await _unitOfWork.CompleteAsync();
            return product.Id;
        }
    }
}
