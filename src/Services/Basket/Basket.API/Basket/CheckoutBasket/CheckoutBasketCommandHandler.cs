using Basket.API.Repositories;
using BuildingBlocks.Messaging.Events;
using MassTransit;

namespace Basket.API.Basket.CheckoutBasket;

public class CheckoutBasketCommandHandler(IBasketRepository repository, IPublishEndpoint publishEndpoint)
    : ICommandHandler<CheckoutBasketCommand, CheckoutBasketCommandResult>
{
    public async Task<CheckoutBasketCommandResult> Handle(CheckoutBasketCommand command, CancellationToken cancellationToken)
    {
        /* TODO:
         * get existing basket with total price
         * set total price on basketcheckout event message
         * send basket checkout event to rabbitmq using masstransit
         * delete the basket   
         */

        var basket = await repository.GetBasketAsync(command.BasketCheckoutDto.UserName, cancellationToken);
        if (basket is null)
        {
            return new CheckoutBasketCommandResult(false);
        }

        var eventMessage = command.BasketCheckoutDto.Adapt<BasketCheckoutEvent>();
        eventMessage.TotalPrice = basket.TotalPrice;

        await publishEndpoint.Publish(eventMessage, cancellationToken);

        await repository.DeleteBasketAsync(command.BasketCheckoutDto.UserName, cancellationToken);

        return new CheckoutBasketCommandResult(true);
    }
}
