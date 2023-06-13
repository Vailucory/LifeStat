using LifeStat.Application.UseCases.Activities;
using LifeStat.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeStat.Api.Controllers;
[Route("api/activities")]
[ApiController]
[Authorize]
public class ActivityController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public ActivityController(IMediator mediator, ICurrentUserIdProvider currentUserIdProvider) : base(currentUserIdProvider)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateActivity(CreateActivityCommand command)
    {
        var userIdResult = UserId;

        if (userIdResult.IsSucceeded)
        {
            command = command with { UserId = userIdResult.Value };

            var result = await _mediator.Send(command);

            return HandleResult(result);
        }

        return HandleResult(userIdResult);
    }

    [HttpGet("template/{templateId}")]
    public async Task<IActionResult> GetActivitiesByTemplateId(int templateId)
    {
        var userIdResult = UserId;

        if (userIdResult.IsSucceeded)
        {
            var result = await _mediator.Send(new GetActivitiesByTemplateIdQuery(templateId, userIdResult.Value));

            return HandleResult(result);
        }

        return HandleResult(userIdResult);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetActivity(int id)
    {
        var userIdResult = UserId;

        if (userIdResult.IsSucceeded)
        {
            var result = await _mediator.Send(new GetActivityQuery(id, userIdResult.Value));

            return HandleResult(result);
        }

        return HandleResult(userIdResult);
    }

    [HttpGet("user")]
    public async Task<IActionResult> GetAllUserActivities()
    {
        var userIdResult = UserId;

        if (userIdResult.IsSucceeded)
        {
            var result = await _mediator.Send(new GetAllUserActivitiesQuery(userIdResult.Value));

            return HandleResult(result);
        }

        return HandleResult(userIdResult);
    }
}
