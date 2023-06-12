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

    public ActivityTemplateController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateActivityTemplate(CreateActivityTemplateCommand command)
    {
        var result = await _mediator.Send(command);

        return HandleResult(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteActivityTemplate(DeleteActivityTemplateCommand command)
    {
        var result = await _mediator.Send(command);

        return HandleResult(result);
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateActivityTemplate(UpdateActivityTemplateCommand command)
    {
        var result = await _mediator.Send(command);

        return HandleResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetActivityTemplate(int id)
    {
        var result = await _mediator.Send(new GetActivityTemplateQuery(id));

        return HandleResult(result);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetAllUserActivityTemplates(int userId)
    {
        var result = await _mediator.Send(new GetAllUserActivityTemplatesQuery(userId));

        return HandleResult(result);
    }
}
