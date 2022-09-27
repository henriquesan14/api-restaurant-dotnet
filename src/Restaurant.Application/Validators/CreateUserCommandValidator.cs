using FluentValidation;
using Restaurant.Application.Commands.UserCommands.CreateUserCommand;

namespace Restaurant.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.FirstName)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(u => u.LastName)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                    .EmailAddress().WithMessage("Endereço de email inválido");
            RuleFor(u => u.Document)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(u => u.PhoneNumber)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(u => u.Password).NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .MinimumLength(6).WithMessage("O campo {PropertyName} precisa ter pelo menos 6 caracteres");
        }
    }
}
