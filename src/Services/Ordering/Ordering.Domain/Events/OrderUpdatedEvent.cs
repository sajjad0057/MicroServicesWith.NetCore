using Ordering.Domain.Abstractions;
using Ordering.Domain.Entities;

namespace Ordering.Domain.Events;

public record OrderUpdatedEvent(Order Order) : IDomainEvent;

