var builder = WebApplication.CreateBuilder(args);

#region Configuring DI

#endregion

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

#region Configuring Request pipe-line

#endregion

app.Run();
