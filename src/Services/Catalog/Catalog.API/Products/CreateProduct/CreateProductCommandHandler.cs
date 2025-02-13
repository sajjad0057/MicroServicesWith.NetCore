namespace Catalog.API.Products.CreateProduct;

internal sealed class CreateProductCommandHandler
    (IDocumentSession session, IValidator<CreateProductCommand> validator)
    : ICommandHandler<CreateProductCommand, CreateProductCommandResult>
{
    public async Task<CreateProductCommandResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //// Business Logic to create a product
        
        var validationResult = await validator.ValidateAsync(command, cancellationToken);
        var errors = validationResult.Errors.Select(x=> x.ErrorMessage).ToList();

        if (errors.Any())
        {
            throw new ValidationException(errors.FirstOrDefault());
        }

        var product = command.Adapt<Product>(); //// using mapster to mapping object


        //// Save to DB
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);

        //// return CreateProductResult result
        return new CreateProductCommandResult(Guid.NewGuid());
    }
}
