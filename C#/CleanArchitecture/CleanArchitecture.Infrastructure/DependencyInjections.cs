namespace CleanArchitecture.Infrastructure;

using CleanArchitecture.Application.Abstractions.Clock;
using CleanArchitecture.Application.Abstractions.Email;
using CleanArchitecture.Infrastructure.Clock;
using CleanArchitecture.Infrastructure.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructure( IConfiguration configuration , IServiceCollection services )
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<IEmailService, EmailService>();

        var connectionString = configuration.GetConnectionString( "Database" )
            ?? throw new ArgumentNullException( nameof( configuration ) );

        services.AddDbContext<ApplicationDbContex>( options => {
             options.UseNpgsql( connectionString ).UseSnakeCaseNamingConvention();
        
        } );

        return services;
    }
}
