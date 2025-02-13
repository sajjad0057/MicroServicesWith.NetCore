namespace Catalog.API.Products.GetProductByCategory;

public sealed record GetProductsByCategoryResponse(IEnumerable<Product> products);

public class GetProductsByCategoryEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
        {
            var result = await sender.Send(new GetProductsByCategoryQuery(category));

            //var response = result.Adapt<GetProductByIdResponse>();  //// here having an unknown issue to map

            return Results.Ok(result);
        })
        .WithName("GetProductsByCategory")
        .Produces<GetProductsByCategoryResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products By Category")
        .WithDescription("Get Products By Category");
    }
}
