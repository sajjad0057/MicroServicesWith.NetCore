using BuildingBlocks.Behaviours;
using BuildingBlocks.Exceptions.Handler;
using Catalog.API.DataSeed;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

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

#region Configuring Carter
builder.Services.AddCarter();
#endregion

#region Configuring Marten
builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);

}).UseLightweightSessions();

//// Configuring Dataseeding with Martern
if (builder.Environment.IsDevelopment())
    builder.Services.InitializeMartenWith<CatalogInitialData>();
#endregion

#region Configuring Custom GlobalExceptionHandler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
#endregion

#region In Service Contariner Registering for Health Check
//// using AspNetCore.HealthChecks.NpgSql package for checking postgresql database server health
builder.Services.AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("Database")!);
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
