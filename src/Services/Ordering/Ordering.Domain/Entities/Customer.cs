using Ordering.Domain.Abstractions;

namespace Ordering.Domain.Entities;

public class Customer : Entity<Guid>
{
    public string Name { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public Customer(string name, string email)
    {
        Name = name;
        Email = email;
    }
}
