namespace CleanArchitecture.Application.Abstractions.Messaging;

using CleanArchitecture.Domain.Abstractions;
using MediatR;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result> where TCommand : ICommand
{
}

public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>> where TCommand : ICommand<TResponse>
{
}
