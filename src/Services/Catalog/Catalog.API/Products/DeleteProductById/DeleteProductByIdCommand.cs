namespace Catalog.API.Products.DeleteProductById;

public sealed record DeleteProductByIdCommand(Guid Id) : ICommand<DeleteProductByIdCommandResult>;

