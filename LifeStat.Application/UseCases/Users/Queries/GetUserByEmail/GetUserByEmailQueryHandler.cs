using LifeStat.Application.Interfaces;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.Users.Queries.GetUserByEmail;
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
