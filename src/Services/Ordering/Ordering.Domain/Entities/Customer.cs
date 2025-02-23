using Ordering.Domain.Abstractions;
using Ordering.Domain.ValueObjects;

namespace Ordering.Domain.Entities;

public class Customer : Entity<CustomerId>
{
    public string Name { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public static Customer Create(CustomerId id, string name, Email email)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(name, nameof(name));

        return new Customer
        {
            Id = id,
            Name = name,
            Email = email
        };
    }
}
