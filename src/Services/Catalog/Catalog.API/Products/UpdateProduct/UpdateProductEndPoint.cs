namespace Catalog.API.Products.UpdateProduct;

public sealed record UpdateProductRequest(Guid Id,
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price);

/// <summary>
/// For Auto Mapping with Mapster mustbe set Parameter with Capital letter otherwise creating issue to mapping.
/// </summary>
/// <param name="IsSuccess"></param>
public sealed record UpdateProductResponse(bool IsSuccess);

public sealed class UpdateProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/products", async (UpdateProductRequest request, ISender sender) =>
        {
            var command = request.Adapt<UpdateProductCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<UpdateProductResponse>();
            return Results.Ok(result);
        })
        .WithName("UpdateProduct")
        .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Update Product")
        .WithDescription("Update Product");
    }
}
