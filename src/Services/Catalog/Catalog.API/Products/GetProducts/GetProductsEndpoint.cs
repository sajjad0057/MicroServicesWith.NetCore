namespace Catalog.API.Products.GetProducts;


/// <summary>
/// For Auto Mapping with Mapster mustbe set Parameter with Capital letter otherwise creating issue to mapping.
/// In Mapster, the default behavior follows C# PascalCase naming conventions, which means that property names 
/// must start with an uppercase letter (e.g., ProductName, Price). If you use camelCase (productName, price),
/// Mapster might fail to map the properties unless explicitly configured.
/// </summary>
/// <param name="Products"></param>
public sealed record GetProductsResponse(IEnumerable<Product> Products);
public sealed record GetProductRequest(int? PageNumber = 1, int? PageSize = 10);

public sealed class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async ([AsParameters] GetProductRequest request, ISender sender) =>
        {
            var query = request.Adapt<GetProductsQuery>();

            var result = await sender.Send(query);

            var response = result.Adapt<GetProductsResponse>();

            return Results.Ok(response);
        })
        .WithName("GetProducts")
        .Produces<GetProductsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products")
        .WithDescription("Get Products");
    }
}
