using MediatR;

namespace Catalog.API.Products.CreateProduct;

public sealed record CreateProductCommand(
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price) : IRequest<CreateProductResult>;

