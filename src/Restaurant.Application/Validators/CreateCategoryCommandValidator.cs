using FluentValidation;
using Restaurant.Application.Commands.CategoryCommands.CreateCategory;
using Restaurant.Core.Entities;

namespace Restaurant.Application.Validators
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(u => u.CategoryType)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .IsInEnum().WithMessage("O campo {PropertyName} é inválido");
        }
    }
}
