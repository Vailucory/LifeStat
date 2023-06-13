using Domain.Models;
using LifeStat.Application.UseCases.WeeklyPlanTemplates;
using LifeStat.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeStat.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class WeeklyPlanTemplateController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public WeeklyPlanTemplateController(IMediator mediator, ICurrentUserIdProvider currentUserIdProvider) : base(currentUserIdProvider)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateWeeklyPlanTemplate(CreateWeeklyPlanTemplateCommand command)
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

    [HttpDelete]
    public async Task<IActionResult> DeleteWeeklyPlanTemplate(int id)
    {
        var userIdResult = UserId;

        if (userIdResult.IsSucceeded)
        {
            var command = new DeleteWeeklyPlanTemplateCommand(id, userIdResult.Value);

            var result = await _mediator.Send(command);

            return HandleResult(result);
        }

        return HandleResult(userIdResult);
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateWeeklyPlanTemplate(WeeklyPlanTemplate weeklyPlanTemplate)
    {
        var userIdResult = UserId;

        if (userIdResult.IsSucceeded)
        {
            var command = new UpdateWeeklyPlanTemplateCommand(weeklyPlanTemplate, userIdResult.Value);

            var result = await _mediator.Send(command);

            return HandleResult(result);
        }

        return HandleResult(userIdResult);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWeeklyPlanTemplate(int id)
    {
        var userIdResult = UserId;

        if (userIdResult.IsSucceeded)
        {
            var result = await _mediator.Send(new GetWeeklyPlanTemplateQuery(id, userIdResult.Value));

            return HandleResult(result);
        }

        return HandleResult(userIdResult);
    }

    [HttpGet("user")]
    public async Task<IActionResult> GetAllUserWeeklyPlanTemplates()
    {
        var userIdResult = UserId;

        if (userIdResult.IsSucceeded)
        {
            var result = await _mediator.Send(new GetAllUserWeeklyPlanTemplatesQuery(userIdResult.Value));

            return HandleResult(result);
        }

        return HandleResult(userIdResult);
    }
}
