using LifeStat.Application.Interfaces;
using MediatR;

namespace LifeStat.Application.UseCases.Users.Queries.GetUserByEmail;
public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQuery, UserViewModel?>
{
    private readonly IIdentityService _identityService;

    public GetUserByEmailQueryHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<UserViewModel?> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        return await _identityService.GetUser(request.Email);
    }
}
