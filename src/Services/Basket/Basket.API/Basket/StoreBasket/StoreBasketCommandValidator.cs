namespace Basket.API.Basket.StoreBasket;

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(x => x.Cart)
            .NotNull().WithMessage("Cart cann't be null or empty");
        RuleFor(x => x.Cart.UserName)
            .NotEmpty().WithMessage("User name is required");
    }
}
