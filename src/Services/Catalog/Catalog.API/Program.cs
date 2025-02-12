var builder = WebApplication.CreateBuilder(args);

#region Configure Services
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

#endregion

#region Configuring DI
#endregion

var app = builder.Build();


#region Configuring Request pipe-line with Carter Library
app.MapCarter();

#endregion

app.Run();
