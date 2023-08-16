using System;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using MediatR;
using Application.Profiles;
using System.Reflection;

namespace Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;

        }
    }
}