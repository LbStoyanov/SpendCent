using SpendCent.API.Middlewares;
using SpendCent.Core;
using SpendCent.Core.Mappers;
using SpendCent.Infrastructure;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


///Add services to the container.


builder.Services.AddInfrastructure();
builder.Services.AddCore();

//Add controllers 
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

var app = builder.Build();

app.UseExceptionHandlingMiddleware(); // Use custom exception handling middleware

//Routing configuration
app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();
//Map controllers to endpoints
app.MapControllers();

app.Run();
