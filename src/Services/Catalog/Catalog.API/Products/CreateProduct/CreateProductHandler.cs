using MediatR;

namespace Catalog.API.Products.CreateProduct;

internal class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
{
    public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        //// Business Logic to create a product
        throw new NotImplementedException();
    }
}
