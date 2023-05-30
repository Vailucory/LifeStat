using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.Users;
public record DeleteUserCommand(Guid Id) : ICommand
{
}
