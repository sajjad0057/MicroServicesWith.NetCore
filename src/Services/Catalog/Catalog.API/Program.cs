using BuildingBlocks.Behaviours;
using BuildingBlocks.Exceptions.Handler;

var builder = WebApplication.CreateBuilder(args);

#region Configure MediatR and PipeLine Behaviours
//// Config MediatR and Behaviours Pipeline -
builder.Services.AddMediatR(config =>
{ 
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
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
#endregion

#region Configuring Custom GlobalExceptionHandler
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
#endregion

#region Configuring DI
#endregion

var app = builder.Build();


#region Configuring Request pipeline
app.MapCarter();
#endregion

#region Configuring ExceptionsHandler pipeline globally
app.UseExceptionHandler(options => { });
#endregion

app.Run();
