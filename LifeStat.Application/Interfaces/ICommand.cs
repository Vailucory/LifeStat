using LifeStat.Domain.Shared;
using MediatR;

namespace LifeStat.Application.Interfaces;
public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>> 
{
}
