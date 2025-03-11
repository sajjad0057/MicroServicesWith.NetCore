namespace Catalog.API.Products.UpdateProduct;

public sealed record UpdateProductCommand(Guid Id,
    string Name,
    List<string> Category,
    string Description,
    string ImageFile,
    decimal Price) 
    : ICommand<UpdateProductCommandResult>;

