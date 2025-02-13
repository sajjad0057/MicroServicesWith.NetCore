namespace Catalog.API.Products.GetProducts;

/// <summary>
/// For Auto Mapping with Mapster mustbe set Parameter with Capital letter otherwise creating issue to mapping.
/// In Mapster, the default behavior follows C# PascalCase naming conventions, which means that property names 
/// must start with an uppercase letter (e.g., ProductName, Price). If you use camelCase (productName, price),
/// Mapster might fail to map the properties unless explicitly configured.
/// </summary>
/// <param name="Products"></param>
public sealed record GetProductsQueryResult(IEnumerable<Product> Products);
