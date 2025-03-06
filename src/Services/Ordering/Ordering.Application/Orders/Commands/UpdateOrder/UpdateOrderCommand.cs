
using BuildingBlocks.CQRS.Interfaces;
using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Commands.UpdateOrder;

public sealed record UpdateOrderCommand(OrderDto Order)
    : ICommand<UpdateOrderCommandResult>;


