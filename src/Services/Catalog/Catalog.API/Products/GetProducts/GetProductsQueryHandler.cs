namespace Catalog.API.Products.GetProducts;

internal sealed class GetProductsQueryHandler(IDocumentSession session, ILogger<GetProductsQueryHandler> logger) 
    : IQueryHandler<GetProductsQuery, GetProductsQueryResult>
{
    public async Task<GetProductsQueryResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation($"GetProductsQueryHandler.Handle called with {query}");

        var products = await session.Query<Product>().ToListAsync(cancellationToken);

        return new GetProductsQueryResult(products);
    }
}
