using Ordering.Domain.Abstractions;
using Ordering.Domain.Entities;

namespace Ordering.Domain.Events;

//// here IDomainEvent is an interface that inherite INotification interface also that's from MediatR library

public record OrderCreatedEvent(Order Order) : IDomainEvent;
