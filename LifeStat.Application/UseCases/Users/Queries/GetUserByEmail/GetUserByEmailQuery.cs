using MediatR;

namespace LifeStat.Application.UseCases.Users.Queries.GetUserByEmail;
public record GetUserByEmailQuery(string Email) : IRequest<UserViewModel?>  
{
}
