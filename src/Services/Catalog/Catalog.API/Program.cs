using Catalog.API.Products.GetProducts;

var builder = WebApplication.CreateBuilder(args);

#region Configure Services
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly)
);

//TypeAdapterConfig<GetProductsQueryResult, GetProductsResponse>.NewConfig()
//    .Map(dest => dest.products, src => src.products);

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
