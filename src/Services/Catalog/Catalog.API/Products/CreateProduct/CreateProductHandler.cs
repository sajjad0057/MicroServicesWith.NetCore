namespace Catalog.API.Products.CreateProduct;

internal sealed class CreateProductHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //// Business Logic to create a product

        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };

        //// Save to DB
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        //// return CreateProductResult result
        return new CreateProductResult(Guid.NewGuid());
    }
}
