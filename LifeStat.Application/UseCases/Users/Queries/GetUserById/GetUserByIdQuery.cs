using MediatR;

namespace LifeStat.Application.UseCases.Users.Queries.GetUser;
public record GetUserByIdQuery(Guid Id) : IRequest<UserViewModel?>
{
}
