using LifeStat.Application.Interfaces;
using MediatR;

namespace LifeStat.Application.UseCases.Users.Commands.ChangePassword;
public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, bool>
{
    private readonly IIdentityService _identityService;

    public ChangePasswordCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<bool> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
    {
        return await _identityService.ChangePasswordAsync(
            request.UserId,
            request.CurrentPassword,
            request.NewPassword);
    }
}
