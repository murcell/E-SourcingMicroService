using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Infastructure.Data;
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
                    configure.MigrationsAssembly("Ordering.Infrastructure.Data");
                });
            });

        }
    }
}
