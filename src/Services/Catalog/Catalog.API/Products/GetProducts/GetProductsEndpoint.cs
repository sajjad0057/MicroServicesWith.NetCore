namespace Catalog.API.Products.GetProducts;

public sealed record GetProductsResponse(IEnumerable<Product> products);

public sealed class GetProductsEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
        {
            var result = await sender.Send(new GetProductsQuery());

            //var response = result.Adapt<GetProductsResponse>(); ////having issue to map, cause unknown now.

            return Results.Ok(result);
        })
        .WithName("GetProducts")
        .Produces<GetProductsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products")
        .WithDescription("Get Products");
    }
}
