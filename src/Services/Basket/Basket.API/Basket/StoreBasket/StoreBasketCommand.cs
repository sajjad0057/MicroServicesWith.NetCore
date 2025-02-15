namespace Basket.API.Basket.StoreBasket;

public sealed record StoreBasketCommand(ShoppingCart Cart) : ICommand<StoreBasketCommandResult>;

