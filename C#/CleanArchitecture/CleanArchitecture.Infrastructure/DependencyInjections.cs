namespace CleanArchitecture.Infrastructure;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructure( IConfiguration configuration , IServiceCollection services )
    {

        return services;
    }
}
