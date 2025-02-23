using Ordering.Domain.Abstractions;

namespace Ordering.Domain.Entities;

public class Product : Entity<Guid>
{
    public string Name { get; private set; } = default!;
    public decimal Price { get; private set; }
    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}
