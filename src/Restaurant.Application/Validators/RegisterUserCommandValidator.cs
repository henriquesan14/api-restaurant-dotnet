using FluentValidation;
using Restaurant.Application.Commands.UserCommands.RegisterUserCommand;

namespace Restaurant.Application.Validators
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
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

            RuleFor(u => u.Street).NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(u => u.Number).NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(u => u.District).NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(u => u.ZipCode).NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");

        }
    }
}
