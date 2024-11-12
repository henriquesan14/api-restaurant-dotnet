using FluentValidation;
using Restaurant.Application.Commands.CategoryCommands.CreateCategory;

namespace Restaurant.Application.Validators
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
}
