using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//{
//    // bu microservise tokendaðýtmaktan görevli arkadaþ
//    options.Authority = builder.Configuration["IdentityServerUrl"];
//    options.Audience = "resource_catalog";
//    options.RequireHttpsMetadata = false;
//});

//builder.Services.AddControllers(opt =>
//{
//    // tüm kontrolleri authorize ettik
//    opt.Filters.Add(new AuthorizeFilter());
//});

//builder.Services.AddScoped<ICategoryService, CategoryService>();
//builder.Services.AddScoped<ICourseService, CourseService>();
//builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

//builder.Services.AddSingleton<IDatabaseSetttings>(sp =>
//{
//    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
//});

//builder.Services.AddMassTransit(x =>
//{
//    x.UsingRabbitMq((context, cfg) =>
//    {
//        cfg.Host(builder.Configuration["RabbitMQUrl"], "/", host =>
//        {
//            host.Username("guest");
//            host.Password("guest");
//        });

//    });
//});

//builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
