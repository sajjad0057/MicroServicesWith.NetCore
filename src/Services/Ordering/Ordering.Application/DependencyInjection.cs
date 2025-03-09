using BuildingBlocks.Behaviours;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using BuildingBlocks.Messaging.Configurations.MassTransit;
using Microsoft.FeatureManagement;

namespace Ordering.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddOpenBehavior(typeof(LoggingBehaviour<,>));
            cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            cfg.AddOpenBehavior(typeof(UnhandledExceptionsBehaviour<,>));
        });


        #region Configuration For Feature Management 
        /*
         Feature Management is a built-in way to use Feature Flags in ASP.NET Core, which allows developers
         to enable or disable specific features without changing any code.
        */
        services.AddFeatureManagement();
        #endregion


        #region Configuring Async Communication(MassTransit.RabbitMQ) Services for message broker
        services.AddMessageBroker(configuration, Assembly.GetExecutingAssembly());
        #endregion


        return services;
    }
}
