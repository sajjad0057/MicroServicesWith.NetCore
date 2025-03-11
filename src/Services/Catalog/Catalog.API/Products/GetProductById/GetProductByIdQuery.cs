namespace Catalog.API.Products.GetProductById;

public sealed record GetProductByIdQuery(Guid Id) : IQuery<GetProductByIdQueryResult>;

