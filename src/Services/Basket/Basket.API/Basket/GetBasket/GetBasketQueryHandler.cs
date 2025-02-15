namespace Basket.API.Basket.GetBasket;

internal sealed class GetBasketQueryHandler : IQueryHandler<GetBasketQuery, GetBasketQueryResult>
{
    public async Task<GetBasketQueryResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        //throw new NotImplementedException();
        await Task.CompletedTask;
        return new GetBasketQueryResult(new ShoppingCart(query.userName));
    }
}
