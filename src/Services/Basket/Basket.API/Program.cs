using Basket.API.Repositories;
using BuildingBlocks.Behaviours;
using BuildingBlocks.Exceptions.Handler;
using Discount.gRPC.Protos;
using HealthChecks.UI.Client;
using Marten;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;


var builder = WebApplication.CreateBuilder(args);

#region Configuring Marten
builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);
    opt.Schema.For<ShoppingCart>().Identity(x => x.UserName);  //// by these set UserName field as Identity field in ShoppingCart Table, plz see marten doc.
}).UseLightweightSessions();
#endregion


#region Configuring IDistributedCache (ItsComeFrom StackExchangeRedis package) with Redis
builder.Services.AddStackExchangeRedisCache(opt =>
{
    opt.Configuration = builder.Configuration.GetConnectionString("Redis");
});
#endregion


#region Configure MediatR and PipeLine Behaviours
//// Config MediatR and Behaviours Pipeline -
/*The configuration sequence is very important when configuring a pipeline.
The behavior that set first here will be executed first. This is what happens
in the case of middleware execution.*/
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(LoggingBehaviour<,>));
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
    config.AddOpenBehavior(typeof(UnhandledExceptionsBehaviour<,>));
});
#endregion


#region FluentValidation Config
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
#endregion


#region Configure DI
builder.Services.AddScoped<IBasketRepository, BasketRepository>();

/*
When you register the same interface (IBasketRepository) multiple times, the last registered service 
(CachedBasketRepository) will overwrite the previous one (BasketRepository). By resolved these issues
Using Scrutor library and following these..
 */
builder.Services.Decorate<IBasketRepository, CachedBasketRepository>();
#endregion

#region Register Discount.gRPC client service with ServiceContainer
//// gRPC services
builder.Services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(opts =>
{
    opts.Address = new Uri(builder.Configuration["gRPCSettings:DiscountUrl"]!);
});
#endregion


#region Configuring Carter
builder.Services.AddCarter();
#endregion


#region Configuring Custom GlobalExceptionHandler 
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
#endregion


#region In Service Contariner Registering for Health Check
//// using AspNetCore.HealthChecks.NpgSql package for checking postgresql database server health
//// using AspNetCore.HealthChecks.Redis package for checking Redis Cache server health
builder.Services.AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("Database")!)
    .AddRedis(builder.Configuration.GetConnectionString("Redis")!);
#endregion

var app = builder.Build();

#region Configuring Request pipeline with Mapping Carter
app.MapCarter();
#endregion


#region Configuring ExceptionsHandler pipeline globally
app.UseExceptionHandler(options => { });
#endregion


#region Map Health Check Endpoint configuring
//// Uisng AspNetCore.HealthChecks.UI.Client package to getting healthcheck information as json format.
app.MapHealthChecks("/health",
    new HealthCheckOptions
    {
        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
    });
#endregion

app.Run();
