using Basket.API.Repositories;

namespace Basket.API.Basket.StoreBasket;

internal sealed class StoreBasketCommandHandler(IBasketRepository repository) 
    : ICommandHandler<StoreBasketCommand, StoreBasketCommandResult>
{
    public async Task<StoreBasketCommandResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        //// TODO : Communicate with Discount.gRPC and calculate lastest price of product into basket/cart
        ///

        //// TODO : store basket in database (use UPSERT, means if exists then update or insert.
        await repository.StoreBasketAsync(command.Cart, cancellationToken);

        //// TODO : UpdateCache

        return new StoreBasketCommandResult(command.Cart.UserName);
    }
}
