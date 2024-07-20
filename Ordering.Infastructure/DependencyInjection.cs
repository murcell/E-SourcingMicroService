using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Domain.Repositories;
using Ordering.Domain.Repositories.Base;
using Ordering.Infastructure.Repositories;
using Ordering.Infastructure.Repositories.Base;

namespace Ordering.Infastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(options =>
                     options.UseSqlServer(
                         configuration.GetConnectionString("DefaultConnection"),
                         b => b.MigrationsAssembly(typeof(OrderDbContext).Assembly.FullName)), ServiceLifetime.Singleton);

            //Add Repositories
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IOrderRepository, OrderRepository>();

            //services.AddTransient<DbContext>(provider => provider.GetRequiredService<IDbContextFactory<OrderDbContext>>().CreateDbContext());
            //services.AddScoped<DbContext>(sp => sp.GetService<OrderDbContext>());

            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //services.AddScoped<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
