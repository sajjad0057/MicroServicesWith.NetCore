namespace Basket.API.Basket.DeleteBasket;

public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketCommandValidator()
    {
        RuleFor(x => x.UserName)
            .NotNull()
            .NotEmpty()
            .WithMessage("User name required");
    }
}
