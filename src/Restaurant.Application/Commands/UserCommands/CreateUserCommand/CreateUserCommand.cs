using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Request;

namespace Restaurant.Application.Commands.UserCommands.CreateUserCommand
{
    public class CreateUserCommand : IRequest<UserViewModel>, ICreatedByRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Document { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public int CreatedByUserId { get; set; }
    }
}
