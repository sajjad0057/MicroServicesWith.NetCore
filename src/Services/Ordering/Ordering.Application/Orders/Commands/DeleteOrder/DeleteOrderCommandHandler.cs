using BuildingBlocks.CQRS.Interfaces;
using BuildingBlocks.Exceptions;
using Ordering.Application.Data;
using Ordering.Domain.ValueObjects;

namespace Ordering.Application.Orders.Commands.DeleteOrder;

public class DeleteOrderCommandHandler(IApplicationDbContext dbContext)
    : ICommandHandler<DeleteOrderCommand, DeleteOrderCommandResult>
{
    public async Task<DeleteOrderCommandResult> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
    {
        ////TODO : Delete Order entity from command object
        //// Save to database
        //// Return result

        var orderId = OrderId.Of(command.OrderId);
        var order = await dbContext.Orders
            .FindAsync([orderId], cancellationToken: cancellationToken);


        if(order is null)
        {
            throw new NotFoundException($"OrderId : {command.OrderId} is not found");
        }

        dbContext.Orders.Remove(order);
        await dbContext.SaveChangesAsync(cancellationToken);
        
        return new DeleteOrderCommandResult(true);
    }
}

