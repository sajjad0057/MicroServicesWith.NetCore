namespace Catalog.API.Products.GetProductByCategory;

public class GetProductsByCategoryQueryHandler(IDocumentSession session, ILogger<GetProductsByCategoryQueryHandler> logger)
    : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryQueryResult>
{
    public async Task<GetProductsByCategoryQueryResult> Handle(GetProductsByCategoryQuery query, 
        CancellationToken cancellationToken)
    {
        logger.LogInformation($"GetProductsByCategoryQueryHandler.Handle called with {query}");

        var products = await session.Query<Product>().Where(p => p.Category.Contains(query.Category)).ToListAsync();

        if (products is null)
            throw new NotFoundException($"Products not found with Category : {query.Category}");

        return new GetProductsByCategoryQueryResult(products);
    }
}
