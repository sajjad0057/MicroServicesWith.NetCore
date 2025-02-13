namespace Catalog.API.Products.GetProductById;

/// <summary>
/// For Auto Mapping with Mapster mustbe set Parameter with Capital letter otherwise creating issue to mapping.
/// In Mapster, the default behavior follows C# PascalCase naming conventions, which means that property names 
/// must start with an uppercase letter (e.g., ProductName, Price). If you use camelCase (productName, price),
/// Mapster might fail to map the properties unless explicitly configured.
/// </summary>
/// <param name="Product"></param>
public sealed record GetProductByIdResponse(Product Product);

public sealed class GetProductByIdEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByIdQuery(id));

            var response = result.Adapt<GetProductByIdResponse>();

            return Results.Ok(response);
        })
        .WithName("GetProductById")
        .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product By Id")
        .WithDescription("Get Product By Id");
    }
}
