using BuildingBlocks.Behaviours;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;



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


#region Configuring DI
#endregion

var app = builder.Build();


#region Configuring Request pipe-line
app.MapCarter();


////Handling Exceptions
app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        if(exception is null)
        {
            return;
        }

        var problemDetails = new ProblemDetails
        {
            Title = exception.Message,
            Status = StatusCodes.Status500InternalServerError,
            Detail = exception.StackTrace
        };

        var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
        logger.LogError(exception, exception.Message, problemDetails);


        context.Response.StatusCode = StatusCodes.Status500InternalServerError;

        context.Response.ContentType = "application/problem+json";

        await context.Response.WriteAsJsonAsync(problemDetails);
    });
});
#endregion

app.Run();
