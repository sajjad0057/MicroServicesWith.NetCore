using BuildingBlocks.Exceptions.Handler;
using Carter;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace Ordering.API;

public static class DependencyInjection
{
    public static IServiceCollection AddApiService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCarter();

        #region In Service Contariner Registering for Health Check
        //// using AspNetCore.HealthChecks.SqlServer package for checking sqlserver database health
        services.AddHealthChecks()
            .AddSqlServer(configuration.GetConnectionString("Database")!);
        #endregion

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

        #region Map Health Check Endpoint configuring
        //// Uisng AspNetCore.HealthChecks.UI.Client package to getting healthcheck information as json format.
        app.UseHealthChecks("/health",
            new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        #endregion

        return app;
    }   
}
