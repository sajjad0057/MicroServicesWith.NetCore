

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.Messaging.Configurations.MassTransit;

public static class Extensions
{
    public static IServiceCollection AddMessageBroker(this IServiceCollection services, IConfiguration configuration)
    {
        //// TODO: put configuration with service container

        #region Implement RabbitMQ MassTransit configuration

        #endregion


        return services;
    }
}
