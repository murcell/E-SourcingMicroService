using ESourcing.Order.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Ordering.Application.DependencyInjections;
using Ordering.Infastructure;
using Ordering.Infastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// builder.Services.AddInfastructure(builder.Configuration);
builder.Services.AddDbContext<OrderDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), configure =>
    {
        //configure.MigrationsAssembly("Ordering.Infastructure");
        configure.MigrationsAssembly(typeof(OrderDbContext).Assembly.FullName);
    });
});

builder.Services.AddApplication();

builder.Services.AddControllers();
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
}

app.UseAuthorization();

app.MapControllers();

app.Run();
