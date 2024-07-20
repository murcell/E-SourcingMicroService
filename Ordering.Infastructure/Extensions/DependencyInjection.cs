using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Domain.Repositories;
using Ordering.Domain.Repositories.Base;
using Ordering.Infastructure;
using Ordering.Infastructure.Repositories;
using Ordering.Infastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infastructure.Extensions
{
    public static class DependencyInjection
    {
        public static void AddInfastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), configure =>
                {
                    configure.MigrationsAssembly(typeof(OrderDbContext).Assembly.FullName);
                });
            });

            services.AddTransient(typeof(IRepository<>),typeof(Repository<>));
            services.AddTransient<IOrderRepository, OrderRepository>();
        }
    }
}
