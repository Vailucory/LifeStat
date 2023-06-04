using LifeStat.Application.UseCases.DailyPlans;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LifeStat.Api.Controllers;
[Route("api/daily-plans")]
[ApiController]
public class DailyPlanController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public DailyPlanController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDailyPlan(CreateDailyPlanCommand command)
    {
        var result = await _mediator.Send(command);

        return HandleResult(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDailyPlan(int id)
    {
        var result = await _mediator.Send(new GetDailyPlanQuery(id));

        return HandleResult(result);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetAllUserDailyPlans(int userId)
    {
        var result = await _mediator.Send(new GetAllUserDailyPlansQuery(userId));

        return HandleResult(result);
    }
}
