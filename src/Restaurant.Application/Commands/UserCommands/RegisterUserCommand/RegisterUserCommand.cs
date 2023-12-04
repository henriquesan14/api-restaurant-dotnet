using MediatR;

namespace Restaurant.Application.Commands.UserCommands.RegisterUserCommand
{
    public class RegisterUserCommand : IRequest<int>
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

    }
}
