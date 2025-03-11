namespace Basket.API.Basket.GetBasket;

public sealed record GetBasketQuery(string userName) : IQuery<GetBasketQueryResult>;