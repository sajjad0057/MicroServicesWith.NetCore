

using BuildingBlocks.CQRS.Interfaces;
using MediatR;

namespace Ordering.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandHandler :
    ICommandHandler<CreateOrderCommand, CreateOrderCommandResult>
{
    public async Task<CreateOrderCommandResult> Handle(CreateOrderCommand command,
        CancellationToken cancellationToken)
    {
        ////TODO : Create Order Entity from command object and save it to database then return operational result.
        
        throw new NotImplementedException();
    }
}
