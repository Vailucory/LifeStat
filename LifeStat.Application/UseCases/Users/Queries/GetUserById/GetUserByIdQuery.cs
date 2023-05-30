using LifeStat.Application.Interfaces;
using LifeStat.Infrastructure.Identity;

namespace LifeStat.Application.UseCases.Users;
public record GetUserByIdQuery(Guid Id) : IQuery<UserViewModel>
{
}
