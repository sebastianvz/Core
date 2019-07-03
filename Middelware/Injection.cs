using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiciosRepositorio;
using DatosCore;
using Reglas;

namespace Middelware
{
    public static class Injection
    {
        public static IServiceCollection InitializeInjecciton(this IServiceCollection service, IConfiguration configuration) {
            service.AddDbContext<TestEFCoreContext>();

            service.AddScoped<IuserService, userService>();
            service.AddScoped<IpersonService, personService>();
            service.AddScoped<IUserRule, UserRule>();
            service.AddScoped<IInclusion, Inclusion>();
            service.AddScoped<IUserRule, UserRule>();
            service.AddScoped<IAutorizationService, AutorizationService>();
            service.AddScoped<IAuthorizationRule, AuthorizationRule>();

            return service;
        }

        
    }
}
