using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.Users.Queries.GetUserByEmail;
public record GetUserByEmailQuery(string Email) : IQuery<UserViewModel>  
{
}
