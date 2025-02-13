using BuildingBlocks.Behaviours;



var builder = WebApplication.CreateBuilder(args);

#region Configure Services
builder.Services.AddCarter();

//// Config MediatR and Behaviours Pipeline -
builder.Services.AddMediatR(config =>
{ 
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
    config.AddOpenBehavior(typeof(ValidationBehaviour<,>));
});


#region FluentValidation Config
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
#endregion

#region Configuring Marten
builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);

}).UseLightweightSessions();
#endregion

#endregion

#region Configuring DI
#endregion

var app = builder.Build();


#region Configuring Request pipe-line with Carter Library
app.MapCarter();

#endregion

app.Run();
