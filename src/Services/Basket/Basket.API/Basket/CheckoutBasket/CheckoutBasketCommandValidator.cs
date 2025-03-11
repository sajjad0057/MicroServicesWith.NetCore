namespace Basket.API.Basket.CheckoutBasket;

public class CheckoutBasketCommandValidator : AbstractValidator<CheckoutBasketCommand>
{
    public CheckoutBasketCommandValidator()
    {
        RuleFor(x => x.BasketCheckoutDto)
            .NotNull()
            .WithMessage("BasketCheckoutDto cann't be null");

        RuleFor(x => x.BasketCheckoutDto.UserName)
            .NotNull()
            .NotEmpty()
            .WithMessage("Username cloud not be null");
    }
}
