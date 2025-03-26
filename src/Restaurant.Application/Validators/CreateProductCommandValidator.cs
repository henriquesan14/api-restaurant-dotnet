using FluentValidation;
using Restaurant.Application.Commands.ProductCommands.CreateProduct;

namespace Restaurant.Application.Validators
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(u => u.CategoryId)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
}
