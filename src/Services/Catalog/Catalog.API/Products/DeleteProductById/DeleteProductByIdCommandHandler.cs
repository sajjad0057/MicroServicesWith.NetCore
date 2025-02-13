namespace Catalog.API.Products.DeleteProductById;

public class DeleteProductByIdCommandHandler(IDocumentSession session, ILogger<DeleteProductByIdCommandHandler> logger)
    : ICommandHandler<DeleteProductByIdCommand, DeleteProductByIdCommandResult>
{
    public async Task<DeleteProductByIdCommandResult> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
    {
        logger.LogInformation($"DeleteProductCommandHandler.Handle executed with command : {command}");

        session.Delete<Product>(command.Id);
        await session.SaveChangesAsync();

        return new DeleteProductByIdCommandResult(true);
    }
}
