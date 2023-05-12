using LifeStat.Application.Interfaces;
using MediatR;

namespace LifeStat.Application.UseCases.Users.Queries.GetUser;
public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel?>
{
    private readonly IIdentityService _identityService;

    public GetUserByIdQueryHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<UserViewModel?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await _identityService.GetUser(request.Id);
    }
}
