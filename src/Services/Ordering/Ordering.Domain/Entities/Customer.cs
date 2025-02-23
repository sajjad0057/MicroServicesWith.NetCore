using Ordering.Domain.Abstractions;
using Ordering.Domain.ValueObjects;

namespace Ordering.Domain.Entities;

public class Customer : Entity<CustomerId>
{
    public string Name { get; private set; } = default!;
    public Email Email { get; private set; } = default!;
    public Customer(string name, Email email)
    {
        Name = name;
        Email = email;
    }
}
