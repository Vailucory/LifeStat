using LifeStat.Domain.Shared;
using MediatR;

namespace LifeStat.Application.Interfaces;
public interface ICommandHandler<TRequest> : IRequestHandler<TRequest, Result>
    where TRequest : ICommand
{
}

public interface ICommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, Result<TResponse>>
    where TRequest : ICommand<TResponse>
    where TResponse : new()
{
}
