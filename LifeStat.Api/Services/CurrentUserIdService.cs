using LifeStat.Domain.Shared;
using LifeStat.Domain.Shared.Errors;
using LifeStat.Infrastructure.Identity;
using Microsoft.Extensions.Caching.Memory;

namespace LifeStat.Api.Services;

public class CurrentUserIdService
{
    private ICurrentUserIdProvider _currentUserIdProvider;

    private IMemoryCache _cache;

    public CurrentUserIdService(ICurrentUserIdProvider currentUserIdProvider, IMemoryCache cache)
    {
        _currentUserIdProvider = currentUserIdProvider;
        _cache = cache;
    }


    public Result<int> GetUserIdResult(string? userSid)
    {
        if (string.IsNullOrEmpty(userSid))
        {
            return Result<int>.FromError(new Error(nameof(userSid), "Invalid Sid."));
        }

        var cachedResult = _cache.Get(userSid) as Result<int>;

        if (cachedResult != null)
        {
            return cachedResult;
        }

        var result = _currentUserIdProvider.GetId(userSid);

        if (result.IsSucceeded)
        {
            _cache.Set(userSid, result, TimeSpan.FromHours(1));
        }

        return result;
    }
}
