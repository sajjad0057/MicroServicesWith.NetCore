namespace Catalog.API.Products.GetProductById;

public class GetProductByIdQueryHandler(IDocumentSession session)
    : IQueryHandler<GetProductByIdQuery, GetProductByIdQueryResult>
{
    public async Task<GetProductByIdQueryResult> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var product = await session.LoadAsync<Product>(query.Id, cancellationToken);

        if (product is null)
            throw new NotFoundException($"Product not found with id : {query.Id}");

        return new GetProductByIdQueryResult(product);
    }
}
