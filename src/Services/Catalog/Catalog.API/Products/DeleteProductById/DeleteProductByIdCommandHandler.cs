namespace Catalog.API.Products.DeleteProductById;

public class DeleteProductByIdCommandHandler(IDocumentSession session)
    : ICommandHandler<DeleteProductByIdCommand, DeleteProductByIdCommandResult>
{
    public async Task<DeleteProductByIdCommandResult> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
    {      
        session.Delete<Product>(command.Id);
        await session.SaveChangesAsync();

        return new DeleteProductByIdCommandResult(true);
    }
}
