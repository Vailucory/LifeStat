using LifeStat.Domain.Shared;
using MediatR;

namespace LifeStat.Application.Interfaces;
public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
