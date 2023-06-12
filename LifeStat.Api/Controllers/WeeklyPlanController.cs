using LifeStat.Application.UseCases.WeeklyPlans;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeStat.Api.Controllers;
[Route("api/weekly-plans")]
[ApiController]
[Authorize]
public class WeeklyPlanController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public WeeklyPlanController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateWeeklyPlan(CreateWeeklyPlanCommand command)
    {
        var result = await _mediator.Send(command);

        return HandleResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetWeeklyPlan(int id)
    {
        var result = await _mediator.Send(new GetWeeklyPlanQuery(id));

        return HandleResult(result);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetAllUserWeeklyPlans(int userId)
    {
        var result = await _mediator.Send(new GetAllUserWeeklyPlansQuery(userId));

        return HandleResult(result);
    }
}
