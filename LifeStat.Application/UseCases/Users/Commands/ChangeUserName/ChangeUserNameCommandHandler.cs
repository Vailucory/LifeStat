using LifeStat.Application.Interfaces;
using MediatR;

namespace LifeStat.Application.UseCases.Users.Commands.ChangeUserName;
internal class ChangeUserNameCommandHandler : IRequestHandler<ChangeUserNameCommand, bool>
{
    private readonly IIdentityService _identityService;

    public ChangeUserNameCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<bool> Handle(ChangeUserNameCommand request, CancellationToken cancellationToken)
    {
        return await _identityService.ChangeUserNameAsync(request.UserId, request.NewUserName);
    }
}
