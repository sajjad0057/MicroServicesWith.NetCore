namespace Catalog.API.Products.GetProductById;

public sealed record GetProductByIdResponse(Product product);

public class GetProductByIdEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products/{id}", async (Guid id, ISender sender) =>
        {
            var result = await sender.Send(new GetProductByIdQuery(id));

            //var response = result.Adapt<GetProductByIdResponse>();  //// here having an unknown issue to map

            return Results.Ok(result);
        })
        .WithName("GetProductById")
        .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product By Id")
        .WithDescription("Get Product By Id");
    }
}
