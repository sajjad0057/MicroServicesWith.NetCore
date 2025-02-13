namespace Catalog.API.Products.GetProductByCategory;

public sealed record GetProductsByCategoryQuery(string Category) : IQuery<GetProductsByCategoryQueryResult>;

