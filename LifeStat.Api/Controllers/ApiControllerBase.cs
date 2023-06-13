using LifeStat.Domain.Shared;
using LifeStat.Domain.Shared.Errors;
using LifeStat.Infrastructure.Identity;
using Microsoft.AspNetCore.Mvc;
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
            return _currentUserIdProvider.GetId(UserSid);
        }
    }

    private ICurrentUserIdProvider _currentUserIdProvider;

    public ApiControllerBase(ICurrentUserIdProvider currentUserIdProvider)
    {
        _currentUserIdProvider = currentUserIdProvider;
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
