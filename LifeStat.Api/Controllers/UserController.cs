using LifeStat.Application.UseCases.Users;
using LifeStat.Domain.Shared;
using LifeStat.Domain.ViewModels;
using LifeStat.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeStat.Api.Controllers;
[Route("api/users")]
[ApiController]
[Authorize]
public class UserController : ApiControllerBase
{
    private IMediator _mediator;

    public UserController(IMediator mediator, ICurrentUserIdProvider currentUserIdProvider) : base(currentUserIdProvider)
    {
        _mediator = mediator;
    }

    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordViewModel changePasswordViewModel)
    {
        var result = await _mediator
            .Send(new ChangePasswordCommand(
                Guid.Parse(UserSid!), 
                changePasswordViewModel.CurrentPassword, 
                changePasswordViewModel.NewPassword));

        return HandleResult(result);
    }

    [HttpPost("change-username")]
    public async Task<IActionResult> ChangeUsername(string newUserName)
    {
        var result = await _mediator.Send(new ChangeUserNameCommand(Guid.Parse(UserSid!), newUserName));

        return HandleResult(result);
    }

    [HttpPost("auth")]
    [AllowAnonymous]
    public async Task<IActionResult> Authenticate(AuthenticateUserCommand command)
    {
        var result = await _mediator.Send(command);

        return HandleResult(result);
    }

    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Register(CreateUserCommand command)
    {
        var result = await _mediator.Send(command);

        return HandleResult(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser()
    {
        var result = await _mediator.Send(new DeleteUserCommand(Guid.Parse(UserSid!)));

        return HandleResult(result);
    }

    [HttpGet]
    public async Task<IActionResult> FindUser(Guid? id, string? email)
    {
        Result<UserViewModel> result;
        if (id is not null && id != Guid.Empty)
        {
            Guid parsedId = Guid.Parse(id.ToString()!);
            result = await _mediator.Send(new GetUserByIdQuery(parsedId));
            return HandleResult(result);
        }
        else if (!string.IsNullOrWhiteSpace(email))
        {
            result = await _mediator.Send(new GetUserByEmailQuery(email));
            return HandleResult(result);
        }

        return StatusCode(StatusCodes.Status500InternalServerError);
    }
}
