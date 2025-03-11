namespace Catalog.API.Products.UpdateProduct;

/// <summary>
/// For Auto Mapping with Mapster mustbe set Parameter with Capital later otherwise creating issue to mapping.
/// </summary>
/// <param name="IsSuccess"></param>
public sealed record UpdateProductCommandResult(bool IsSuccess);
