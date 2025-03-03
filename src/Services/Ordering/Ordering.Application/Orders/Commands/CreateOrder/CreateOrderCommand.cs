
using BuildingBlocks.CQRS.Interfaces;
using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Commands.CreateOrder;

public sealed record CreateOrderCommand(OrderDto OrderDto) : ICommand<CreateOrderCommandResult>
{
}
