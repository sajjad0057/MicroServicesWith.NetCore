
namespace Ordering.Domain.Abstractions;


public interface IAggregate<T> : IAggregate, IEntity<T>
{
}

public interface IAggregate : IEntiry
{
    IReadOnlyList<IDomainEvent> DomainEvents { get; }
    IDomainEvent[] ClearDomainEvents();
}
