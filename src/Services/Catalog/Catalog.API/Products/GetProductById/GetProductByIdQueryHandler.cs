namespace Catalog.API.Products.GetProductById;

public class GetProductByIdQueryHandler(IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdQueryResult>
{
    public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation($"GetProductByIdQueryHandler.Handle called with {query}");

        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

        if (product is null)
            throw new NotFoundException($"Product not found with id : {query.Id}");

        return new GetProductByIdQueryResult(product);
    }
}
