using LifeStat.Domain.Shared;
using MediatR;

namespace LifeStat.Application.Interfaces;
public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, Result<TResponse>>
    where TRequest : IQuery<TResponse>
    where TResponse : new()
{
}
