using LifeStat.Api.Services;
using LifeStat.Application.UseCases.DailyPlanTemplates;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeStat.Api.Controllers;
[Route("api/daily-plan-templates")]
[ApiController]
[Authorize]
public class DailyPlanTemplateController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public DailyPlanTemplateController(
        IMediator mediator,
        CurrentUserIdService currentUserIdService)
        : base(currentUserIdService)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDailyPlanTemplate(CreateDailyPlanTemplateCommand command)
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
    public async Task<IActionResult> DeleteDailyPlanTemplate(int id)
    {
        var userIdResult = UserId;

        if (userIdResult.IsSucceeded)
        {
            var command = new DeleteDailyPlanTemplateCommand(id, userIdResult.Value);

            var result = await _mediator.Send(command);

            return HandleResult(result);
        }

        return HandleResult(userIdResult);
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateDailyPlanTemplate(UpdateDailyPlanTemplateCommand command)
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDailyPlanTemplate(int id)
    {
        var userIdResult = UserId;

        if (userIdResult.IsSucceeded)
        {
            var result = await _mediator.Send(new GetDailyPlanTemplateQuery(id, userIdResult.Value));

            return HandleResult(result);
        }

        return HandleResult(userIdResult);
    }

    [HttpGet("user")]
    public async Task<IActionResult> GetAllUserDailyPlanTemplates()
    {
        var userIdResult = UserId;

        if (userIdResult.IsSucceeded)
        {
            var result = await _mediator.Send(new GetAllUserDailyPlanTemplatesQuery(userIdResult.Value));

            return HandleResult(result);
        }

        return HandleResult(userIdResult);
    }
}
