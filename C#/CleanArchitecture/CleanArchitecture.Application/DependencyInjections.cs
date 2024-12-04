namespace CleanArchitecture.Application;

#region usings
using CleanArchitecture.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
#endregion

public static class DependencyInjections
{
   public static IServiceCollection AddApplication( this IServiceCollection services)
   {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(typeof(DependencyInjections).Assembly);
        });

        services.AddTransient<PricesService>();

        return services;
   }
}
