﻿using MediatR;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Commands.ProductCategoryCommands.DeleteCategory
{
    public class DeleteProductCategoryCommandHandler : IRequestHandler<DeleteProductCategoryCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteProductCategoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
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
