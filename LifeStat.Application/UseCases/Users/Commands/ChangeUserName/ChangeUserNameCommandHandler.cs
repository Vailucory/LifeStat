﻿using LifeStat.Application.Interfaces;
using LifeStat.Domain.Shared;
using LifeStat.Infrastructure.Identity;

namespace LifeStat.Application.UseCases.Users;
public class ChangeUserNameCommandHandler : ICommandHandler<ChangeUserNameCommand>
{
    private readonly IIdentityService _identityService;

    public ChangeUserNameCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<Result> Handle(ChangeUserNameCommand request, CancellationToken cancellationToken)
    {
        return await _identityService.ChangeUserNameAsync(request.UserId, request.NewUserName);
    }
}
