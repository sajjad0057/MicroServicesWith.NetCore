namespace Catalog.API.Products.CreateProduct;

internal sealed class CreateProductCommandHandler(IDocumentSession session)
    : ICommandHandler<CreateProductCommand, CreateProductCommandResult>
{
    public async Task<CreateProductCommandResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //// Business Logic to create a product here  
        
        var product = command.Adapt<Product>(); //// using mapster to mapping object.

        //// Save to DB
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        //// return CreateProductResult result
        return new CreateProductCommandResult(Guid.NewGuid());
    }
}
