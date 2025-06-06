﻿namespace Catalog.API.Products.GetProductsByCategory;

public class GetProductsByCategoryQueryHandler(IDocumentSession session)
    : IQueryHandler<GetProductsByCategoryQuery, GetProductsByCategoryQueryResult>
{
    public async Task<GetProductsByCategoryQueryResult> Handle(GetProductsByCategoryQuery query, 
        CancellationToken cancellationToken)
    {
        var products = await session.Query<Product>().Where(p => p.Category.Contains(query.Category)).ToListAsync();

        if (products is null)
            throw new NotFoundException($"Products not found with Category : {query.Category}");

        return new GetProductsByCategoryQueryResult(products);
    }
}
