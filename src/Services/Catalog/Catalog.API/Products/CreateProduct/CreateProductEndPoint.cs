namespace Catalog.API.Products.CreateProduct;

public sealed record CreateProductRequest(string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price);


/// <summary>
/// For Auto Mapping with Mapster mustbe set Parameter with Capital letter otherwise creating issue to mapping.
/// In Mapster, the default behavior follows C# PascalCase naming conventions, which means that property names 
/// must start with an uppercase letter (e.g., ProductName, Price). If you use camelCase (productName, price),
/// Mapster might fail to map the properties unless explicitly configured.
/// </summary>
/// <param name="Id"></param>
public sealed record CreateProductResponse(Guid Id);


public sealed class CreateProductEndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/products",
            async (CreateProductRequest request, ISender sender) =>
        {
            var command = request.Adapt<CreateProductCommand>();

            var result = await sender.Send(command);

            var response = result.Adapt<CreateProductResponse>();

            return Results.Created($"/products/{response.Id}", response);
        })
        .WithName("CreateProduct")
        .Produces<CreateProductResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Product")
        .WithDescription("Create Product");
    }
}
