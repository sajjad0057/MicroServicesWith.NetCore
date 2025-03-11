using BuildingBlocks.CQRS.Interfaces;

namespace Ordering.Application.Orders.Commands.DeleteOrder;

public sealed record DeleteOrderCommand(Guid OrderId) : ICommand<DeleteOrderCommandResult>;

