using Discount.gRPC.Data;
using Microsoft.EntityFrameworkCore;

namespace Discount.gRPC.Extensions;

/// <summary>
/// Extensions class to create extension method here .
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Using these UseMigration extension method can doing auto migrate and update db 
    /// when running these service , for these not need to doing command to genarate 
    /// and update migrations to database.
    /// </summary>
    public static IApplicationBuilder UseMigration(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<DiscountContext>();

        dbContext.Database.MigrateAsync();

        return app;
    }
}
