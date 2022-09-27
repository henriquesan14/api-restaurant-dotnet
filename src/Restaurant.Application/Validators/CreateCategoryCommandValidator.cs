using FluentValidation;
using Restaurant.Core.Entities;
using Restaurant.Core.Enums;

namespace Restaurant.Application.Validators
{
    public class CreateCategoryCommandValidator : AbstractValidator<Category>
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
