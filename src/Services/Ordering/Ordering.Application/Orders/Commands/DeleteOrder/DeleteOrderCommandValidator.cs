using FluentValidation;

namespace Ordering.Application.Orders.Commands.DeleteOrder;

class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderCommandValidator()
    {
       RuleFor(x => x.OrderId).NotEmpty().WithMessage("OrderId is required");
    }
}
