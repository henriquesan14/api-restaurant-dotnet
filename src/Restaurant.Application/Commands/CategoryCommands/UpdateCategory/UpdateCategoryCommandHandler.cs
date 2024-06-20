using AutoMapper;
using MediatR;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Commands.CategoryCommands.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, int>
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
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
