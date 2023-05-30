using LifeStat.Application.Interfaces;
using LifeStat.Infrastructure.Identity;

namespace LifeStat.Application.UseCases.Users;
public record GetUserByEmailQuery(string Email) : IQuery<UserViewModel>  
{
}
