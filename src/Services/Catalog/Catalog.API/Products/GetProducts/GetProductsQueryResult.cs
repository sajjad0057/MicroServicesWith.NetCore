namespace Catalog.API.Products.GetProducts;

/// <summary>
/// For Auto Mapping with Mapster mustbe set Parameter with Capital letter otherwise creating issue to mapping.
/// </summary>
/// <param name="Products"></param>
public sealed record GetProductsQueryResult(IEnumerable<Product> Products);
