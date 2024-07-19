using ESourcing.Order.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ordering.Application.DependencyInjections;
using Ordering.Infastructure;
using Ordering.Infastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(opt =>
{

});

// Add services to the container. builder.Services.AddInfastructure(builder.Configuration);

builder.Services.AddInfastructure(builder.Configuration);
builder.Services.AddApplication();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.MigrateAndSeedDatabase();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseDeveloperExceptionPage();
}

//app.UseAuthorization();

app.MapControllers();

app.Run();
