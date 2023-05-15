using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.Users.Commands.CreateUser;
public record CreateUserCommand(string UserName, string Email, string Password) : ICommand<Guid>
{
}
