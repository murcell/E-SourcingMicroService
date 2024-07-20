using AutoMapper;
using ESourcing.Order.Consumers;
using ESourcing.Order.Extensions;
using ESourcing.Order.Mapping;
using EventBusRabbitMQ;
using Microsoft.EntityFrameworkCore;
using Ordering.Application;
using Ordering.Infastructure;
using RabbitMQ.Client;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(opt =>
{

});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly()); 

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<OrderMapping>();
});

var mapper = config.CreateMapper();

builder.Services.AddInfastructure(builder.Configuration);
builder.Services.AddApplication();


#region EventBus

builder.Services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
{
    var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();
    var factory = new ConnectionFactory()
    {
        HostName = builder.Configuration["EventBus:HostName"],
    };

    if (!string.IsNullOrWhiteSpace(builder.Configuration["EventBus:UserName"]))
    {
        factory.UserName = builder.Configuration["EventBus:UserName"];
    }
    if (!string.IsNullOrWhiteSpace(builder.Configuration["EventBus:Password"]))
    {
        factory.Password = builder.Configuration["EventBus:Password"];
    }

    var retryCount = 5;
    if (!string.IsNullOrWhiteSpace(builder.Configuration["EventBus:RetryCount"]))
    {
        retryCount = int.Parse(builder.Configuration["EventBus:RetryCount"]);
    }

    return new DefaultRabbitMQPersistentConnection(factory, retryCount, logger);

});


builder.Services.AddSingleton<EventBusOrderCreateConsumer>();

 #endregion


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.MigrateAndSeedDatabase();

app.UseEventBusListener();


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
