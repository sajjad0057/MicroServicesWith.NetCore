using Basket.API.Repositories;

namespace Basket.API.Basket.GetBasket;

internal sealed class GetBasketQueryHandler(IBasketRepository repository) 
    : IQueryHandler<GetBasketQuery, GetBasketQueryResult>
{
    public async Task<GetBasketQueryResult> Handle(GetBasketQuery query, CancellationToken cancellationToken)
    {
        var basket = await repository.GetBasketAsync(query.userName);

        return new GetBasketQueryResult(basket);
    }
}
