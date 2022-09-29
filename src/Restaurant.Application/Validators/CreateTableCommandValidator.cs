using FluentValidation;
using Restaurant.Application.Commands.TableCommands.CreateTable;

namespace Restaurant.Application.Validators
{
    public class CreateTableCommandValidator : AbstractValidator<CreateTableCommand>
    {
        public CreateTableCommandValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
}
