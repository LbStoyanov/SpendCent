using SpendCent.Core;
using SpendCent.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


///Add services to the container.


builder.Services.AddInfrastructure();
builder.Services.AddCore();

//Add controllers 
builder.Services.AddControllers();

var app = builder.Build();

//Routing configuration

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();
//Map controllers to endpoints
app.MapControllers();

app.Run();
