namespace Catalog.API.Products.CreateProduct;

internal sealed class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductCommandResult>
{
    public async Task<CreateProductCommandResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //// Business Logic to create a product

        //var product = new Product
        //{
        //    Name = command.Name,
        //    Category = command.Category,
        //    Description = command.Description,
        //    ImageFile = command.ImageFile,
        //    Price = command.Price
        //};

        var product = command.Adapt<Product>(); //// using mapster to mapping object


        //// Save to DB
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        //// return CreateProductResult result
        return new CreateProductCommandResult(Guid.NewGuid());
    }
}
