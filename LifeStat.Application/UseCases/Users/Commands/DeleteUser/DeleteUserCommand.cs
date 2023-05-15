using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.Users.Commands.DeleteUser;
public record DeleteUserCommand(Guid Id) : ICommand
{
}
