using MediatR;

namespace LifeStat.Application.UseCases.Users.Commands.CreateUser;
public record CreateUserCommand(string UserName, string Email, string Password) : IRequest<Guid?>
{
}
