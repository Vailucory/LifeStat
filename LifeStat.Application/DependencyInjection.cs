using FluentValidation;
using LifeStat.Application.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LifeStat.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(conf => conf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

        ValidatorOptions.Global.LanguageManager.Culture = new System.Globalization.CultureInfo("en-US");

        services.AddValidatorsFromAssemblyContaining(typeof(DependencyInjection));

        return services;
    }
}
