namespace CleanArchitecture.Application.Abstractions.Messaging;

using CleanArchitecture.Domain.Abstractions;
using MediatR;

public interface ICommand : IRequest<Result>, IBaseCommand
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
{

}

public interface IBaseCommand { }
