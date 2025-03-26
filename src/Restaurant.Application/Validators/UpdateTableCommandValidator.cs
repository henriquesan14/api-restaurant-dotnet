using FluentValidation;
using Restaurant.Application.Commands.TableCommands.UpdateTable;

namespace Restaurant.Application.Validators
{
    public class UpdateTableCommandValidator : AbstractValidator<UpdateTableCommand>
    {
        public UpdateTableCommandValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(u => u.Capacity)
                .GreaterThan(0).WithMessage("O campo {PropertyName} é inválido");
        }
    }
}
