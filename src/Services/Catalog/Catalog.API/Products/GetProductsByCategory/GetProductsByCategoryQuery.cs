namespace Catalog.API.Products.GetProductsByCategory;

public sealed record GetProductsByCategoryQuery(string Category) : IQuery<GetProductsByCategoryQueryResult>;

