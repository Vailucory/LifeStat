using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.Users.Queries.GetUser;
public record GetUserByIdQuery(Guid Id) : IQuery<UserViewModel>
{
}
