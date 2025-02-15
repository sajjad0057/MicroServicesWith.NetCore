
namespace Basket.API.Basket.StoreBasket;

internal sealed class StoreBasketCommandHandler : ICommandHandler<StoreBasketCommand, StoreBasketCommandResult>
{
    public async Task<StoreBasketCommandResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        var cart = command.Cart;
        //// TODO : store basket in database (use UPSERT, means if exists then update or insert.
        //// TODO : UpdateCache
        await Task.CompletedTask;
        return new StoreBasketCommandResult(cart.UserName);
    }
}
