using FluentValidation;
using Restaurant.Application.Queries.UserQueries;

namespace Restaurant.Application.Validators
{
    public class LoginUserValidator : AbstractValidator<LoginUserQuery>
    {
        public LoginUserValidator()
        {
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .EmailAddress().WithMessage("O campo {PropertyName} é inválido");
            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
}
