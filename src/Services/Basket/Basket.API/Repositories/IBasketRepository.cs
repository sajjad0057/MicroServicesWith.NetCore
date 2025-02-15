namespace Basket.API.Repositories;

public interface IBasketRepository
{
    Task<ShoppingCart> GetBasketAsync(string userName, CancellationToken cancellationToken = default);
    Task<ShoppingCart> StoreBasketAsync(ShoppingCart cart, CancellationToken cancellationToken = default);
    Task<bool> DeleteBasketAsync(string userName, CancellationToken cancellationToken = default);
}
