using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);


#region Configuring Reverse proxy with YARP (Yet Another Reverse Proxy)
//// Configuring YARP with DI container
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
#endregion


#region Configuring ratelimiting with YARP settings
builder.Services.AddRateLimiter(rateLimiterOptions =>
{
    rateLimiterOptions.AddFixedWindowLimiter("fixed", options =>
    {
        options.Window = TimeSpan.FromSeconds(10);
        options.PermitLimit = 5;
    });
});
#endregion


//// Add services to the container
var app = builder.Build();

//// Configure the HTTP request pipleline
#region Configuring ratelimiting middleware with request pipeline
app.UseRateLimiter();
#endregion

#region Configuration Reverse proxy with http request pipeline
app.MapReverseProxy();
#endregion

app.Run();
