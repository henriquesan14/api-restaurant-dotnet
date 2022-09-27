using MediatR;
using Restaurant.Application.ViewModels;

namespace Restaurant.Application.Commands.UserCommands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<UserViewModel>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Document { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
