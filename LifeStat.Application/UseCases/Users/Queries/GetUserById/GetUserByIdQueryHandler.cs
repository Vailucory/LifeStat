using LifeStat.Application.Interfaces;
using LifeStat.Domain.Shared;
using LifeStat.Infrastructure.Identity;

namespace LifeStat.Application.UseCases.Users;
public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserViewModel>
{
    private readonly IIdentityService _identityService;

    public GetUserByIdQueryHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<Result<UserViewModel>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await _identityService.GetUser(request.Id);
    }
}
