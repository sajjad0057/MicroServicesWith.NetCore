namespace Catalog.API.Products.GetProductsByCategory;
/// <summary>
/// For Auto Mapping with Mapster mustbe set Parameter with Capital GetProductsByCategoryResponse otherwise creating issue to mapping.
/// </summary>
/// <param name="Products"></param>
public sealed record GetProductsByCategoryQueryResult(IEnumerable<Product> Products);
