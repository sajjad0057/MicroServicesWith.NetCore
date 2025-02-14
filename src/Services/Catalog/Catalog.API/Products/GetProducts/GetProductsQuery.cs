namespace Catalog.API.Products.GetProducts;

public sealed record GetProductsQuery(int? PageNumber = 1, int? PageSize = 10) : IQuery<GetProductsQueryResult>;

