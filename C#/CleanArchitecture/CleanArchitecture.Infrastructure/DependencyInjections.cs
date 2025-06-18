namespace CleanArchitecture.Infrastructure;

using CleanArchitecture.Application.Abstractions.Clock;
using CleanArchitecture.Application.Abstractions.Data;
using CleanArchitecture.Application.Abstractions.Email;
using CleanArchitecture.Domain.Abstractions;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Infrastructure.Clock;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Email;
using CleanArchitecture.Infrastructure.Repositories;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructure( this IServiceCollection services, IConfiguration configuration )
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider>();
        services.AddTransient<IEmailService, EmailService>();

        var connectionString = configuration.GetConnectionString( "Database" )
            ?? throw new ArgumentNullException( nameof( configuration ) );

        services.AddDbContext<ApplicationDbContex>( options => {
             options.UseNpgsql( connectionString ).UseSnakeCaseNamingConvention();
        
        } );

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICarRepository, CarRepository>();
        services.AddScoped<IRentalRepository, RentalRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContex>() );

        services.AddSingleton<ISqlConnectionFactory>( _ =>  new SQLConnectionFactory( connectionString ) );

        SqlMapper.AddTypeHandler( new DateOnlyTypeHandler()  );

        return services;
    }
}
