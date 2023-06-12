using LifeStat.Application.Interfaces;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.Users;
public class AuthenticateUserCommandHandler : ICommandHandler<AuthenticateUserCommand, string>
{
    private readonly IJwtTokenAuthenticationService _jwtAuthenticationService;

    public AuthenticateUserCommandHandler(IJwtTokenAuthenticationService jwtAuthenticationService)
    {
        _jwtAuthenticationService = jwtAuthenticationService;
    }

    public async Task<Result<string>> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        return await _jwtAuthenticationService.Authenticate(request.Email, request.Password);
    }
}
