using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.Users.Commands.ChangeUserName;
public record ChangeUserNameCommand(Guid UserId, string NewUserName) : ICommand
{
}
