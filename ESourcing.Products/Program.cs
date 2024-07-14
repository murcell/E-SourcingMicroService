using ESourcing.Products.Data.Interfaces;
using ESourcing.Products.Repositories;
using ESourcing.Products.Repositories.Interfaces;
using ESourcing.Products.Settings;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(opt =>
{

});

builder.Services.Configure<ProductDatabaseSettings>(builder.Configuration.GetSection("ProductDatabaseSettings"));

builder.Services.AddSingleton<IProductDatabaseSettings>(sp =>  sp.GetRequiredService<IOptions<ProductDatabaseSettings>>().Value );

builder.Services.AddTransient<IProductContext, ProductContext>();
builder.Services.AddTransient< IProductRepository, ProductRepository>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}

//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

app.Run();
