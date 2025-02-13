namespace Catalog.API.Products.CreateProduct;

internal sealed class CreateProductCommandHandler
    (IDocumentSession session, ILogger<CreateProductCommandHandler> logger)
    : ICommandHandler<CreateProductCommand, CreateProductCommandResult>
{
    public async Task<CreateProductCommandResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //// Business Logic to create a product here  

        logger.LogInformation($"CreateProductCommandHandler.Handle called with command : {command}");

        var product = command.Adapt<Product>(); //// using mapster to mapping object.

        //// Save to DB
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        //// return CreateProductResult result
        return new CreateProductCommandResult(Guid.NewGuid());
    }
}
