using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Queries.UserQueries
{
    public class LoginUserQuery : IRequest<AuthResponseViewModel>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
