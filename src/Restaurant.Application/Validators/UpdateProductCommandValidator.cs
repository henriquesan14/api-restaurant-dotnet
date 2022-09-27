using FluentValidation;
using Restaurant.Application.Commands.ProductCommands.UpdateProduct;

namespace Restaurant.Application.Validators
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(u => u.Price)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} não pode ser igual ou menor que 0");
            RuleFor(u => u.ImageUrl)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(u => u.CategoryId)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
}
