using FluentValidation;
using Restaurant.Application.Commands.OrderCommands.CreateDeliveryOrder;

namespace Restaurant.Application.Validators
{
    public class CreateDeliveryOrderCommandValidator : AbstractValidator<CreateDeliveryOrderCommand>
    {
        public CreateDeliveryOrderCommandValidator()
        {
            RuleFor(u => u.Items)
                .Must(x => x == null || x.Any())
                .WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(u => u.Items)
                .ForEach(x => x.SetValidator(new OrderItemInputModelValidator()));
            RuleFor(u => u.AddressId)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
}
