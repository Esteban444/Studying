namespace CleanArchitecture.Application.Abstractions.Messaging;

using CleanArchitecture.Domain.Abstractions;
using MediatR;

public interface IQueryHandler<TQuery,TResponse> : IRequestHandler<TQuery,Result<TResponse>>
    where TQuery : IQuery<TResponse>
{
}

