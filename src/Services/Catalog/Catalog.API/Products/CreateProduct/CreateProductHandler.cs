using BuildingBlocks.CQRS.Interfaces;
using Catalog.API.Models;

namespace Catalog.API.Products.CreateProduct;

internal class CreateProductHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        //// Business Logic to create a product
        //// Save to DB
        //// return CreateProductResult result

        var product = new Product
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price
        };

        await Task.CompletedTask;

        return new CreateProductResult(Guid.NewGuid());
    }
}
