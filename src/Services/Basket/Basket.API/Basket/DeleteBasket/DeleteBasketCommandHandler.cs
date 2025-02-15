namespace Basket.API.Basket.DeleteBasket;

public class DeleteBasketCommandHandler
    : ICommandHandler<DeleteBasketCommand, DeleteBasketCommandResult>
{
    public async Task<DeleteBasketCommandResult> Handle(DeleteBasketCommand commad, CancellationToken cancellationToken)
    {
        //// TODO : Delete Basket from DB
        
        await Task.CompletedTask;
        return new DeleteBasketCommandResult(true);
    }
}
