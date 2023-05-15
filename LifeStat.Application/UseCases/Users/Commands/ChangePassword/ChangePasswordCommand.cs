using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.Users.Commands.ChangePassword;
public record ChangePasswordCommand(Guid UserId, string CurrentPassword, string NewPassword) : ICommand
{
}
