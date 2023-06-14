using LifeStat.Api.Services;
using LifeStat.Domain.Shared;
using LifeStat.Domain.Shared.Errors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LifeStat.Api.Controllers;

public class ApiControllerBase : ControllerBase
{
    protected string? UserSid { get => HttpContext.User.FindFirst(ClaimTypes.Sid)?.Value; }

    protected Result<int> UserId { get => _currentUserIdService.GetUserIdResult(UserSid); }

    private readonly CurrentUserIdService _currentUserIdService;

    public ApiControllerBase(CurrentUserIdService currentUserIdService)
    {
        _currentUserIdService = currentUserIdService;
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
