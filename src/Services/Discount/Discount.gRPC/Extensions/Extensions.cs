using Discount.gRPC.Data;
using Microsoft.EntityFrameworkCore;

namespace Discount.gRPC.Extensions;

/// <summary>
/// Extensions class to create extension method here .
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Using these UseMigration extension method can doing auto update DB by migrations file 
    /// when running these service , for these not need to doing command to update migrations to database.
    /// </summary>
    public static async Task<IApplicationBuilder> UseUpdateMigrationToDb(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<DiscountContext>();

        await dbContext.Database.MigrateAsync();

        return app;
    }
}
