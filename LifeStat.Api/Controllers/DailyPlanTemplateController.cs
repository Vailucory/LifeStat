using LifeStat.Application.UseCases.DailyPlanTemplates;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LifeStat.Api.Controllers;
[Route("api/daily-plan-templates")]
[ApiController]
public class DailyPlanTemplateController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public DailyPlanTemplateController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDailyPlanTemplate(CreateDailyPlanTemplateCommand command)
    {
        var result = await _mediator.Send(command);

        return HandleResult(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteDailyPlanTemplate(DeleteDailyPlanTemplateCommand command)
    {
        var result = await _mediator.Send(command);

        return HandleResult(result);
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateDailyPlanTemplate(UpdateDailyPlanTemplateCommand command)
    {
        var result = await _mediator.Send(command);

        return HandleResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDailyPlanTemplate(int id)
    {
        var result = await _mediator.Send(new GetDailyPlanTemplateQuery(id));

        return HandleResult(result);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetAllUserDailyPlanTemplates(int userId)
    {
        var result = await _mediator.Send(new GetAllUserDailyPlanTemplatesQuery(userId));

        return HandleResult(result);
    }
}
