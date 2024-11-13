using AutoMapper;
using MediatR;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Commands.ProductCategoryCommands.UpdateCategory
{
    public class UpdateProductCategoryCommandHandler : IRequestHandler<UpdateProductCategoryCommand, int>
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProductCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(request.Id);
            if(category == null)
            {
                return 0;
            }
            var categoryEntity = _mapper.Map(request, category);
            _unitOfWork.Categories.UpdateAsync(categoryEntity);
            await _unitOfWork.CompleteAsync();
            return categoryEntity.Id;
        }
    }
}
