namespace Catalog.API.Products.GetProducts;

internal sealed class GetProductsQueryHandler(IDocumentSession session) 
    : IQueryHandler<GetProductsQuery, GetProductsQueryResult>
{
    public async Task<GetProductsQueryResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>().ToListAsync(cancellationToken);

        return new GetProductsQueryResult(products);
    }
}
