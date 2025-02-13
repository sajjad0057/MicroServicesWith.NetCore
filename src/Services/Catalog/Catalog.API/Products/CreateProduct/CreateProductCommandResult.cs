namespace Catalog.API.Products.CreateProduct;

/// <summary>
/// For Auto Mapping with Mapster mustbe set Parameter with Capital letter otherwise creating issue to mapping.
/// </summary>
/// <param name="Id"></param>
public sealed record CreateProductCommandResult(Guid Id);

