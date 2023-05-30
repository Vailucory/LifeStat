using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.Users;
public record GetUserByIdQuery(Guid Id) : IQuery<UserViewModel>
{
}
