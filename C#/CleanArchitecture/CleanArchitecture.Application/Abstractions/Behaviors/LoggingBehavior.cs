namespace CleanArchitecture.Application.Abstractions.Behaviors;

using CleanArchitecture.Application.Abstractions.Messaging;
using MediatR;
using Microsoft.Extensions.Logging;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IBaseCommand
{
    private readonly ILogger<TRequest> logger;

    public LoggingBehavior( ILogger<TRequest> logger )
    {
        this.logger = logger;
    }

    public async Task<TResponse> Handle( TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken )
    {
        var name = request.GetType().Name;

        try
        {
            logger.LogInformation( $"Ausführung of the command requet: {name}" );
            var result = await next();
            logger.LogInformation( $"Ausfuhrung completed: {name}" );

            return result;
        }
        catch ( Exception ex)
        {
            logger.LogError( ex, $"Error: {ex.Message}" );
            throw;
        }
    }
}
