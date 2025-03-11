using Discount.gRPC.Data;
using Discount.gRPC.Extensions;
using Discount.gRPC.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

#region Adding Configurations for using Sqlite with EF Core
builder.Services.AddDbContext<DiscountContext>(opts =>
    opts.UseSqlite(builder.Configuration.GetConnectionString("Database")));

#endregion

var app = builder.Build();

#region Configure the HTTP request pipeline.
//// Using UseMigration extension method to autoupdate migration to DB, when applicaiton started
app.UseUpdateMigrationToDb();

app.MapGrpcService<DiscountService>();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client." +
" To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

#endregion


app.Run();
