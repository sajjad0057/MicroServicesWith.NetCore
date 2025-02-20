using Basket.API.Repositories;
using Discount.gRPC.Protos;

namespace Basket.API.Basket.StoreBasket;

internal sealed class StoreBasketCommandHandler(IBasketRepository repository,
    DiscountProtoService.DiscountProtoServiceClient  discountProto) 
    : ICommandHandler<StoreBasketCommand, StoreBasketCommandResult>
{
    public async Task<StoreBasketCommandResult> Handle(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        await DeductDiscountAsync(command.Cart, cancellationToken);

        //// TODO : store basket in database (use UPSERT, means if exists then update or insert.
        await repository.StoreBasketAsync(command.Cart, cancellationToken);

        //// TODO : UpdateCache

        return new StoreBasketCommandResult(command.Cart.UserName);
    }

    /// <summary>
    /// using gRPC commucination deduct cart item discount
    /// </summary>
    /// <param name="cart"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    private async Task DeductDiscountAsync(ShoppingCart cart, CancellationToken cancellationToken)
    {
        //// TODO : Communicate with Discount.gRPC and calculate lastest price of product into basket/cart

        foreach (var item in cart.Items)
        {
            var coupon = await discountProto
                .GetDiscountAsync(new GetDiscountRequest { ProductName = item.ProductName },
                cancellationToken: cancellationToken);

            item.Price -= coupon.Amount;
        }
    }
}
