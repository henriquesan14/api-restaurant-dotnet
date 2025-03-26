using MediatR;
using Restaurant.Application.ViewModels;
using Restaurant.Core.Common;

namespace Restaurant.Application.Commands.UserCommands.RegisterUserCommand
{
    public class RegisterUserCommand : IRequest<Result<UserViewModel>>
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string Document { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string District { get; set; }
        public string ZipCode { get; set; }
        public string Complement { get; set; }

        public int CityId { get; set; }

        public int RoleId { get; set; }

    }
}
