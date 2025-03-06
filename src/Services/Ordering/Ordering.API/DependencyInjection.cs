using BuildingBlocks.Exceptions.Handler;
using Carter;

namespace Ordering.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiService(this IServiceCollection services)
    {
        services.AddCarter();

        #region Configuring Custom GlobalExceptionHandler 
        services.AddExceptionHandler<GlobalExceptionHandler>();
        #endregion

        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        app.MapCarter();

        #region Configuring ExceptionsHandler pipeline globally
        app.UseExceptionHandler(options => { });
        #endregion

        return app;
    }   
}
