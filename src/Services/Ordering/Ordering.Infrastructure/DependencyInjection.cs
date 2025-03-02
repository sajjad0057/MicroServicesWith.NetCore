using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Infrastructure.Data;
using Ordering.Infrastructure.Data.Interceptors;

namespace Ordering.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Database");

        #region AddServicesToTheContainer


        services.AddDbContext<ApplicationDbContext>(options =>
        {
            //// Add the interceptor to the options for these when dbcontext is called then the interceptor will be called
            options.AddInterceptors(new AuditableEntityInterceptor());
            options.UseSqlServer(connectionString);
        });


        #endregion



        return services;
    }
}
