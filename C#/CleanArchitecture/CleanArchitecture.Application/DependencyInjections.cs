namespace CleanArchitecture.Application;

#region usings
using CleanArchitecture.Application.Abstractions.Behaviors;
using CleanArchitecture.Domain.Services;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
#endregion

public static class DependencyInjections
{
   public static IServiceCollection AddApplication( this IServiceCollection services)
   {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(typeof(DependencyInjections).Assembly);
            configuration.AddOpenBehavior( typeof( LoggingBehavior<,>) );
            configuration.AddOpenBehavior( typeof( ValidationBehavior<,> ) );
        });

        services.AddValidatorsFromAssembly( typeof( DependencyInjections ).Assembly );

        services.AddTransient<PricesService>();

        return services;
   }
}
