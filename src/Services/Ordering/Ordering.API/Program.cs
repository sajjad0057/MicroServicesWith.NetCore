using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

//// Add services to the container using extension methods 

builder.Services
    .AddApplicationService()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiService();

var app = builder.Build();

////Configure the HTTP request pipeline


app.Run();
