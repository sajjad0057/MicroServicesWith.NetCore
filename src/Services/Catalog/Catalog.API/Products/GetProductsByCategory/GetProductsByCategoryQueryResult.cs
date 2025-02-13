namespace Catalog.API.Products.GetProductByCategory;

public sealed record GetProductsByCategoryQueryResult(IEnumerable<Product> products);
