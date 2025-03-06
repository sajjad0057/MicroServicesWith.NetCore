using Carter;

namespace Ordering.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiService(this IServiceCollection services)
    {
        services.AddCarter();
        return services;
    }

    public static WebApplication UseApiServices(this WebApplication app)
    {
        app.MapCarter();
        return app;
    }   
}
