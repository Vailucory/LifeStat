using LifeStat.Application.UseCases.WeeklyPlanTemplates;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LifeStat.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WeeklyPlanTemplateController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public WeeklyPlanTemplateController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateWeeklyPlanTemplate(CreateWeeklyPlanTemplateCommand command)
    {
        var result = await _mediator.Send(command);

        return HandleResult(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteWeeklyPlanTemplate(DeleteWeeklyPlanTemplateCommand command)
    {
        var result = await _mediator.Send(command);

        return HandleResult(result);
    }

    [HttpPatch]
    public async Task<IActionResult> UpdateWeeklyPlanTemplate(UpdateWeeklyPlanTemplateCommand command)
    {
        var result = await _mediator.Send(command);

        return HandleResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWeeklyPlanTemplate(int id)
    {
        var result = await _mediator.Send(new GetWeeklyPlanTemplateQuery(id));

        return HandleResult(result);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetAllUserWeeklyPlanTemplates(int userId)
    {
        var result = await _mediator.Send(new GetAllUserWeeklyPlanTemplatesQuery(userId));

        return HandleResult(result);
    }
}
