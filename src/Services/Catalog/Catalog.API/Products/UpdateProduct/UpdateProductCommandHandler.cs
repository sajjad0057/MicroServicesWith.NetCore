namespace Catalog.API.Products.UpdateProduct;

public class UpdateProductCommandHandler(IDocumentSession session, ILogger<UpdateProductCommandHandler> logger) :
    ICommandHandler<UpdateProductCommand, UpdateProductCommandResult>
{
    public async Task<UpdateProductCommandResult> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation($"UpdateProductCommandHandler.Handle executed with command  : {command}");

        var product = await session.LoadAsync<Product>(command.Id, cancellationToken);

        if (product is null)
            throw new NotFoundException($"Product not found with id : {command.Id}");

        command.Adapt(product); //// here command as a src and product as a dest.

        session.Update(product);
        await session.SaveChangesAsync(cancellationToken);

        return new UpdateProductCommandResult(true);
    }
}
