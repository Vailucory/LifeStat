namespace LifeStat.Application.Interfaces;
public interface IJwtTokenAuthenticationService
{
    Task<string?> Authenticate(string Email, string Password);
}
