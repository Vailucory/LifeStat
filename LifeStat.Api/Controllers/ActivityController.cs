using LifeStat.Application.UseCases.Activities;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace LifeStat.Api.Controllers;
[Route("api/activities")]
[ApiController]
public class ActivityController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public ActivityController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateActivity(CreateActivityCommand command)
    {
        var result = await _mediator.Send(command);

        return HandleResult(result);
    }

    [HttpGet("template/{templateId}")]
    public async Task<IActionResult> GetActivitiesByTemplateId(int templateId)
    {
        var result = await _mediator.Send(new GetActivitiesByTemplateIdQuery(templateId));

        return HandleResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetActivity(int id)
    {
        var result = await _mediator.Send(new GetActivityQuery(id));

        return HandleResult(result);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetAllUserActivities(int userId)
    {
        var result = await _mediator.Send(new GetAllUserActivitiesQuery(userId));

        return HandleResult(result);
    }
}
