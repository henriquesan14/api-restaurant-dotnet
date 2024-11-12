using FluentValidation;
using Restaurant.Application.Commands.CategoryCommands.UpdateCategory;

namespace Restaurant.Application.Validators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
}
