using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Repositories;
using Restaurant.Core.Services;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurant.Application.Queries.UserQueries
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, AuthResponseViewModel>
    {
        private readonly IUserRepository _repository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public LoginUserQueryHandler(IUserRepository repository, ITokenService tokenService, IMapper mapper)
        {
            _repository = repository;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<AuthResponseViewModel> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var userExists = await _repository.GetByEmail(request.Email);
            if (userExists == null)
                return null;
            bool password = BCrypt.Net.BCrypt.Verify(request.Password, userExists.Password);
            if (!password)
            {
                return null;
            }
            var token = _tokenService.GenerateToken(userExists);
            userExists.Password = null;
            return new AuthResponseViewModel
            {
                Token = token,
                User = _mapper.Map<UserViewModel>(userExists)
            };
        }
    }
}
