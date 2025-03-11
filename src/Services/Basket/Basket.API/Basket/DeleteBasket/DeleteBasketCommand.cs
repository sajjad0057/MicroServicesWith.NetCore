namespace Basket.API.Basket.DeleteBasket;

public sealed record DeleteBasketCommand(string UserName) : ICommand<DeleteBasketCommandResult>;
