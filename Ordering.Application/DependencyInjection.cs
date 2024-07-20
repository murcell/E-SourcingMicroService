using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ordering.Application.Commands.OrderCreate;
using Ordering.Application.Handlers;
using Ordering.Application.Mapper;
using Ordering.Application.PipelineBehaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<IValidator<OrderCreateCommand>, OrderCreateValidator>();

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining(typeof(OrderCreateCommandHandler));
                // cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                //cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
                //cfg.AddOpenBehavior(typeof(PerformanceBehavior<,>));
                //cfg.AddOpenBehavior(typeof(UnhandledExceptionBehavior<,>));

            });

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));

            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<OrderProfile>();
            });

            var mapper = config.CreateMapper();

            return services;
        }
    }
}
