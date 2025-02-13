namespace Catalog.API.Products.GetProducts;

public sealed record GetProductsQueryResult(IEnumerable<Product> products);
