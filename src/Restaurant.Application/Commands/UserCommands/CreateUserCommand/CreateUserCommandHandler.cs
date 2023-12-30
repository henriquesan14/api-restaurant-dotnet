using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Entities;
using Restaurant.Core.Exceptions;
using Restaurant.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Commands.UserCommands.CreateUserCommand
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserViewModel>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserViewModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            User userExist = await _repository.GetByEmail(request.Email);
            if (userExist != null)
            {
                throw new UserAlreadyExistsException("Já possui um usuário com este email.");
            }
            request.Password = BCrypt.Net.BCrypt.HashPassword(request.Password, 8);
            User userCreated = await _repository.AddAsync(_mapper.Map<User>(request));

            return _mapper.Map<UserViewModel>(userCreated);
        }
    }
}
