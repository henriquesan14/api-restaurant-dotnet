using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Common;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Commands.MenuCategoryCommands.CreateMenuCategory
{
    public class CreateMenuCategoryCommandHandler : IRequestHandler<CreateMenuCategoryCommand, Result<MenuCategoryViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMenuCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<MenuCategoryViewModel>> Handle(CreateMenuCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<MenuCategory>(request);

            await _unitOfWork.MenuCategories.AddAsync(entity);

            await _unitOfWork.CompleteAsync();

            var viewModel = _mapper.Map<MenuCategoryViewModel>(entity);

            return Result<MenuCategoryViewModel>.Success(viewModel);

        }
    }
}
