using LifeStat.Application.Interfaces;
using MediatR;

namespace LifeStat.Application.UseCases.Users.Commands.CreateUser;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid?>
{
    private readonly IIdentityService _identityService;

    public CreateUserCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<Guid?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        return await _identityService.CreateUserAsync(
            request.UserName,
            request.Email,
            request.Password);
    }
}
