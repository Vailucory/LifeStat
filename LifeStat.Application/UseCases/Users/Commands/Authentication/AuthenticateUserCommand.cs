using LifeStat.Application.Interfaces;

namespace LifeStat.Application.UseCases.Users;
public record AuthenticateUserCommand(string Email, string Password) : ICommand<string>
{ 
}
