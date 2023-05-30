using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.Users;
public record ChangeUserNameCommand(Guid UserId, string NewUserName) : ICommand
{
}
