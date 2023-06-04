using LifeStat.Application.UseCases.Users;
using LifeStat.Domain.Shared;
using LifeStat.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LifeStat.Api.Controllers;
[Route("api/users")]
[ApiController]
public class UserController : ApiControllerBase
{
    private IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("change-password")]
    public async Task<IActionResult> ChangePassword(ChangePasswordCommand command)
    {
        var result = await _mediator.Send(command);

        return HandleResult(result);
    }

    [HttpPost("change-username")]
    public async Task<IActionResult> ChangeUsername(ChangeUserNameCommand command)
    {
        var result = await _mediator.Send(command);

        return HandleResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> Register(CreateUserCommand command)
    {
        var result = await _mediator.Send(command);

        return HandleResult(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUser(DeleteUserCommand command)
    {
        var result = await _mediator.Send(command);

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

    //[HttpGet]
    //public async Task<IActionResult> GetByEmail(string email)
    //{
    //    var result = await _mediator.Send(new GetUserByEmailQuery(email));

    //    return HandleResult(result);
    //}
}
