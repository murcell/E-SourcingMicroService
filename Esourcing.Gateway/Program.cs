using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

//builder.Configuration.AddJsonFile($"configuration.{builder.Environment.EnvironmentName.ToLower()}.json");
builder.Configuration.AddJsonFile("ocelot.json");

// Add services to the container.
builder.Services.AddOcelot();

var app = builder.Build();

// Configure the HTTP request pipeline.


//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});


await app.UseOcelot();
app.Run();
