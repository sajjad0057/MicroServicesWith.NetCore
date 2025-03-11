using Ordering.Domain.Abstractions;
using Ordering.Domain.ValueObjects;

namespace Ordering.Domain.Entities;

public class Product : Entity<ProductId>
{
    public string Name { get; private set; } = default!;
    public decimal Price { get; private set; }
    private Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public static Product Create(ProductId id, string name, decimal price)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));

        return new Product(name, price) { Id = id };
    }
}
