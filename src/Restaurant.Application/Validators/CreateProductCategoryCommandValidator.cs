using FluentValidation;
using Restaurant.Application.Commands.ProductCategoryCommands.CreateCategory;


namespace Restaurant.Application.Validators
{
    public class CreateProductCategoryCommandValidator : AbstractValidator<CreateProductCategoryCommand>
    {
        public CreateProductCategoryCommandValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
}
