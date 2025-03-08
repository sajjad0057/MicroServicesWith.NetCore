using Basket.API.Dtos;

namespace Basket.API.Basket.CheckoutBasket;

public record CheckoutBasketCommand(BasketCheckoutDto BasketCheckoutDto) : ICommand<CheckoutBasketCommandResult>;

