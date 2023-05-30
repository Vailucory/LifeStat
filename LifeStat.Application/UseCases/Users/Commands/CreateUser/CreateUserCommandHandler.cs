using LifeStat.Application.Interfaces;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.Users;
public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand, Guid>
{
    private readonly IIdentityService _identityService;

    public CreateUserCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<Result<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        return await _identityService.CreateUserAsync(
            request.UserName,
            request.Email,
            request.Password);
    }
}
