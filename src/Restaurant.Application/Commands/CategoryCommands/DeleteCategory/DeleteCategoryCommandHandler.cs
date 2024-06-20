using MediatR;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Commands.CategoryCommands.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(request.Id);
            if(category == null)
            {
                return 0;
            }
            _unitOfWork.Categories.DeleteAsync(category);
            await _unitOfWork.CompleteAsync();
            return category.Id;
        }
    }
}
