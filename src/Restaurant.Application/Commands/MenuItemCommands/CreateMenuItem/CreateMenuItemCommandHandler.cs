using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Common;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Commands.MenuItemCommands.CreateMenuItem
{
    public class CreateMenuItemCommandHandler : IRequestHandler<CreateMenuItemCommand, Result<MenuItemViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMenuItemCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<MenuItemViewModel>> Handle(CreateMenuItemCommand request, CancellationToken cancellationToken)
        {
            
            var entity = _mapper.Map<MenuItem>(request);

            await _unitOfWork.MenuItems.AddAsync(entity);

            try
            {
                await _unitOfWork.CompleteAsync();
            }catch(Exception e)
            {

            } 


            var viewModel = _mapper.Map<MenuItemViewModel>(entity);

            return Result<MenuItemViewModel>.Success(viewModel);
        }
    }
}
