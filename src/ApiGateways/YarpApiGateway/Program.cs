var builder = WebApplication.CreateBuilder(args);


#region Configuring Reverse proxy with YARP (Yet Another Reverse Proxy)
//// Configuring YARP with DI container
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
#endregion


//// Add services to the container
var app = builder.Build();


//// Configure the HTTP request pipleline
#region Configuration Reverse proxy with http request pipeline
app.MapReverseProxy();
#endregion

app.Run();
