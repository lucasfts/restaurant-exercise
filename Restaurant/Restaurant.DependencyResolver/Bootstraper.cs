using Microsoft.Extensions.DependencyInjection;
using Restaurant.Business;
using Restaurant.Business.Contracts;
using Restaurant.Data;
using System;

namespace Restaurant.DependencyResolver
{
    public static class Bootstraper
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();

            services.AddScoped<OrderService>();

            return services;
        }
    }
}
