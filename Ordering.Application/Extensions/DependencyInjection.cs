using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.DependencyInjections
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddFluentValidationAutoValidation(config =>
            {
               // config.DisableDataAnnotationsValidation = true;
            });

            services.AddMediatR(cfg =>
            {
               // cfg.RegisterServicesFromAssembly(typeof(Ordering.Application.Handlers.CreateOrderCommandHandler).Assembly);
               
            });
        }
    }
}
