using LifeStat.Domain.Shared;
using LifeStat.Domain.Shared.Errors;
using LifeStat.Infrastructure.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Security.Claims;

namespace LifeStat.Api.Controllers;

public class ApiControllerBase : ControllerBase
{
    protected string? UserSid { get => HttpContext.User.FindFirst(ClaimTypes.Sid)?.Value; }

    protected Result<int> UserId
    {
        get
        {
            if (string.IsNullOrEmpty(UserSid))
            {
                return Result<int>.FromError(new Error(nameof(UserSid), "Invalid Sid."));
            }

            var cachedResult = _cache.Get(UserSid) as Result<int>;

            if (cachedResult != null)
            {
                return cachedResult;
            }

            var result = _currentUserIdProvider.GetId(UserSid);

            if (result.IsSucceeded) 
            {
                _cache.Set(UserSid, result, TimeSpan.FromHours(1));
            }

            return result;
        }
    }

    private ICurrentUserIdProvider _currentUserIdProvider;

    protected IMemoryCache _cache;

    public ApiControllerBase(ICurrentUserIdProvider currentUserIdProvider, IMemoryCache cache)
    {
        _currentUserIdProvider = currentUserIdProvider;
        _cache = cache;
    }

    protected IActionResult HandleResult<T>(Result<T> result)
    {
        if (result.IsSucceeded)
        {
            return Ok(result.Value);
        }

        return HandleErrors(result.Errors);
    }

    protected IActionResult HandleResult(Result result)
    {
        if (result.IsSucceeded)
        {
            return Ok();
        }

        return HandleErrors(result.Errors);
    }

    private IActionResult HandleErrors(Error[] errors)
    {

        if (!errors.Any())
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        return BadRequest(errors);
    }
}
