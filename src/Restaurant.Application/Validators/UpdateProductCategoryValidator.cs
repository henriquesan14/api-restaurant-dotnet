using FluentValidation;
using Restaurant.Application.Commands.ProductCategoryCommands.UpdateCategory;

namespace Restaurant.Application.Validators
{
    public class UpdateProductCategoryValidator : AbstractValidator<UpdateProductCategoryCommand>
    {
        public UpdateProductCategoryValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
}
