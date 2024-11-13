using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Common;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Commands.MenuCommands.CreateMenu
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, Result<MenuViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMenuCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<MenuViewModel>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Menu>(request);

            await _unitOfWork.Menus.AddAsync(entity);

            await _unitOfWork.CompleteAsync();

            var viewModel = _mapper.Map<MenuViewModel>(entity);
            return Result<MenuViewModel>.Success(viewModel);
        }
    }
}
