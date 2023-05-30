using LifeStat.Application.Interfaces;
using LifeStat.Domain.Shared;
using LifeStat.Infrastructure.Identity;

namespace LifeStat.Application.UseCases.Users;
public class GetUserByEmailQueryHandler : IQueryHandler<GetUserByEmailQuery, UserViewModel>
{
    private readonly IIdentityService _identityService;

    public GetUserByEmailQueryHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<Result<UserViewModel>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        return await _identityService.GetUser(request.Email);
    }
}
