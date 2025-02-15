using Basket.API.Repositories;

namespace Basket.API.Basket.DeleteBasket;

internal sealed class DeleteBasketCommandHandler(IBasketRepository repository)
    : ICommandHandler<DeleteBasketCommand, DeleteBasketCommandResult>
{
    public async Task<DeleteBasketCommandResult> Handle(DeleteBasketCommand commad, CancellationToken cancellationToken)
    {
        //// TODO : Delete Basket from DB
        await repository.DeleteBasketAsync(commad.UserName,cancellationToken);

        return new DeleteBasketCommandResult(true);
    }
}
