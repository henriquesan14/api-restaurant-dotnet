using AutoMapper;
using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Entities;
using Restaurant.Core.Errors;
using Restaurant.Core.Exceptions;
using Restaurant.Core.Repositories;
using Restaurant.Core.Services;
using System.Linq.Expressions;

namespace Restaurant.Application.Queries.UserQueries
{
    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, AuthResponseViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public LoginUserQueryHandler(IUnitOfWork unitOfWork, ITokenService tokenService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        public async Task<AuthResponseViewModel> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {

            Expression<Func<User, bool>> predicate = u =>
                (u.Email.Equals(request.Email));

            List<Expression<Func<User, object>>> includes = new List<Expression<Func<User, object>>>
            {
                e => e.Role,
                e => e.Addresses
            };

            var list = await _unitOfWork.Users.GetAsync(predicate, includes: includes);
            var userExists = list.FirstOrDefault();
            if (userExists == null)
                throw new UnauthorizedException(ErrorMessages.UNAUTHORIZED);

            bool password = BCrypt.Net.BCrypt.Verify(request.Password, userExists.Password);
            if (!password)
            {
                throw new UnauthorizedException(ErrorMessages.UNAUTHORIZED);
            }
            var token = _tokenService.GenerateToken(userExists);
            return new AuthResponseViewModel
            {
                AccessToken = token,
                User = _mapper.Map<UserViewModel>(userExists)
            };
        }
    }
}
