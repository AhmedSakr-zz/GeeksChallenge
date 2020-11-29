using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using GeeksChallenge.CloudLibrary.Application.Implementations;
using GeeksChallenge.CloudLibrary.Application.Interfaces;
using GeeksChallenge.CloudLibrary.Services.CloudProvider;
using Microsoft.Extensions.DependencyInjection;

namespace GeeksChallenge.CloudLibrary
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<IInfrastructureService, InfrastructureService>();
            services.AddScoped<IServicesService, ServicesService>();
            return services;

        }
    }
}
