using FluentValidation;
using Restaurant.Application.Commands.OrderCommands.CreateCommonOrder;

namespace Restaurant.Application.Validators
{
    public class CreateCommonOrderCommandValidator : AbstractValidator<CreateCommonOrderCommand>
    {
        public CreateCommonOrderCommandValidator()
        {
            RuleFor(u => u.Items)
                .Must(x => x == null || x.Any())
                .WithMessage("O campo {PropertyName} é obrigatório");
            RuleFor(u => u.Items)
                .ForEach(x=>x.SetValidator(new OrderItemInputModelValidator()));
            RuleFor(u => u.TableId)
                .NotEmpty().WithMessage("O campo {PropertyName} é obrigatório");
        }
    }
}
