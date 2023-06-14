using Domain.Enums;
using Domain.Models;
using LifeStat.Api.Services;
using LifeStat.Application.UseCases.ActivityTemplates;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeStat.Api.Controllers;
[Route("api/activity-templates")]
[ApiController]
[Authorize]
public class ActivityTemplateController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public ActivityTemplateController(
        IMediator mediator,
        CurrentUserIdService currentUserIdService)
        : base(currentUserIdService)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateActivityTemplate(string name, ActivityType activityType)
    {
        var userIdResult = UserId;

        if (userIdResult.IsSucceeded)
        {
            var command = new CreateActivityTemplateCommand(userIdResult.Value, name, activityType);

            var result = await _mediator.Send(command);

            return HandleResult(result);
        }

        return HandleResult(userIdResult);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteActivityTemplate(int activityTemplateId)
    {
        var userIdResult = UserId;

        if (userIdResult.IsSucceeded)
        {
            var command = new DeleteActivityTemplateCommand(activityTemplateId, userIdResult.Value);

            var result = await _mediator.Send(command);

            return HandleResult(result);
        }

        return HandleResult(userIdResult);
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateActivityTemplate(ActivityTemplate activityTemplate)
    {
        var userIdResult = UserId;

        if (userIdResult.IsSucceeded)
        {
            var command = new UpdateActivityTemplateCommand(activityTemplate, userIdResult.Value);

            var result = await _mediator.Send(command);

            return HandleResult(result);
        }

        return HandleResult(userIdResult);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetActivityTemplate(int id)
    {
        var userIdResult = UserId;

        if (userIdResult.IsSucceeded)
        {
            var result = await _mediator.Send(new GetActivityTemplateQuery(id, userIdResult.Value));

            return HandleResult(result);
        }

        return HandleResult(userIdResult);
    }

    [HttpGet("user")]
    public async Task<IActionResult> GetAllUserActivityTemplates()
    {
        var userIdResult = UserId;

        if (userIdResult.IsSucceeded)
        {
            var result = await _mediator.Send(new GetAllUserActivityTemplatesQuery(userIdResult.Value));

            return HandleResult(result);
        }

        return HandleResult(userIdResult);
    }
}
