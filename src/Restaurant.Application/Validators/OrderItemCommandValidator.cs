using FluentValidation;
using Restaurant.Application.Commands.OrderCommands;

namespace Restaurant.Application.Validators
{
    public class OrderItemCommandValidator : AbstractValidator<OrderItemCommand>
    {
        public OrderItemCommandValidator()
        {
            RuleFor(o => o.ProductId)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório")
                .GreaterThanOrEqualTo(0).WithMessage("O campo {PropertyName} tem que ser maior que 0");
            RuleFor(o => o.Quantity)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
}
