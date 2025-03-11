namespace Catalog.API.Products.GetProductById;

/// <summary>
/// For Auto Mapping with Mapster mustbe set Parameter with Capital letter otherwise creating issue to mapping.
/// </summary>
/// <param name="Product"></param>
public sealed record GetProductByIdQueryResult(Product Product);
