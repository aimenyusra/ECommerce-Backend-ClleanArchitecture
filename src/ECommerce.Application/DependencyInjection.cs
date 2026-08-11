using System.Reflection;
using ECommerce.Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        var applicationAssembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(cfg =>
        {
            cfg.LicenseKey = configuration["MediatR:LicenseKey"];
            cfg.RegisterServicesFromAssembly(applicationAssembly);
            cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
        });

        services.AddValidatorsFromAssembly(applicationAssembly);

        services.AddAutoMapper(cfg =>
        {
            cfg.LicenseKey = configuration["AutoMapper:LicenseKey"];
        }, applicationAssembly);

        return services;
    }
}