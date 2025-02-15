using Marten;

namespace Basket.API.Repositories;

public class BasketRepository(IDocumentSession session)
    : IBasketRepository
{
    public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
    {
        var basket = await session.LoadAsync<ShoppingCart>(userName, cancellationToken);

        return basket ?? throw new NotFoundException($"Shopping cart not found for this user");
    }

    public async Task<ShoppingCart> StoreBasket(ShoppingCart cart, CancellationToken cancellationToken = default)
    {
        //// UPSERT Operations with martern
        session.Store(cart);

        await session.SaveChangesAsync(cancellationToken);

        return cart;    
    }

    public async Task<bool> DeleteBasket(string userName, CancellationToken cancellationToken = default)
    {
        session.Delete<ShoppingCart>(userName);

        await session.SaveChangesAsync(cancellationToken);

        return true;
    }
}
