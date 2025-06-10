using SpendCent.API.Middlewares;
using SpendCent.Core;
using SpendCent.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


///Add services to the container.


builder.Services.AddInfrastructure();
builder.Services.AddCore();

//Add controllers 
builder.Services.AddControllers();

var app = builder.Build();

app.UseExceptionHandlingMiddleware(); // Use custom exception handling middleware

//Routing configuration
app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();
//Map controllers to endpoints
app.MapControllers();

app.Run();
