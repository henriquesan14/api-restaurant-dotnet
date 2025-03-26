using FluentValidation;
using Restaurant.Application.InputModels;

namespace Restaurant.Application.Validators
{
    public class OrderItemInputModelValidator : AbstractValidator<OrderItemInputModel>
    {
        public OrderItemInputModelValidator() {
            RuleFor(u => u.MenuItemId)
                .NotNull()
                .WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(u => u.Quantity)
                .NotNull()
                .WithMessage("O campo {PropertyName} é obrigatório");

        }
    }
}
