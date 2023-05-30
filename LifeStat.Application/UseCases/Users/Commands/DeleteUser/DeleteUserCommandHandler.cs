using LifeStat.Application.Interfaces;
using LifeStat.Domain.Shared;
using LifeStat.Infrastructure.Identity;

namespace LifeStat.Application.UseCases.Users;
public class DeleteUserCommandHandler : ICommandHandler<DeleteUserCommand>
{
    private readonly IIdentityService _identityService;

    public DeleteUserCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        return await _identityService.DeleteUserAsync(request.Id);
    }
}
