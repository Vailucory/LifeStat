using LifeStat.Domain.Shared;

namespace LifeStat.Application.Interfaces;
public interface IJwtTokenAuthenticationService
{
    Task<Result<string>> Authenticate(string Email, string Password);
}
