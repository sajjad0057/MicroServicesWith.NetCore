namespace Catalog.API.Products.GetProductsByCategory;

/// <summary>
/// For Auto Mapping with Mapster mustbe set Parameter with Capital letter otherwise creating issue to mapping.
/// </summary>
/// <param name="Products"></param>
public sealed record GetProductsByCategoryResponse(IEnumerable<Product> Products);

public sealed class GetProductsByCategoryEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
        {
            var result = await sender.Send(new GetProductsByCategoryQuery(category));

            var response = result.Adapt<GetProductsByCategoryResponse>();

            return Results.Ok(response);
        })
        .WithName("GetProductsByCategory")
        .Produces<GetProductsByCategoryResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products By Category")
        .WithDescription("Get Products By Category");
    }
}
