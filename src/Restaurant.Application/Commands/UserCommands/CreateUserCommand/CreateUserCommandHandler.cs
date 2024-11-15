using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Common;
using Restaurant.Core.Entities;
using Restaurant.Core.Errors;
using Restaurant.Core.Repositories;

namespace Restaurant.Application.Commands.UserCommands.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result<UserViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<UserViewModel>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User userExist = await _unitOfWork.Users.GetByEmail(request.Email);
            if (userExist != null)
            {
                return Result<UserViewModel>.Failure(ErrorMessages.USER_EMAIL_ALREADY_EXISTS);
            }
            request.Password = BCrypt.Net.BCrypt.HashPassword(request.Password, 8);
            var entity = _mapper.Map<User>(request);
            await _unitOfWork.Users.AddAsync(entity);

            await _unitOfWork.CompleteAsync();

            var viewModel = _mapper.Map<UserViewModel>(entity);

            return Result<UserViewModel>.Success(viewModel);
        }
    }
}
