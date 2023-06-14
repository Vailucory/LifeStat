using LifeStat.Api.Services;
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

    public WeeklyPlanController(
        IMediator mediator,
        CurrentUserIdService currentUserIdService)
        : base(currentUserIdService)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateWeeklyPlan(CreateWeeklyPlanCommand command)
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
    public async Task<IActionResult> GetWeeklyPlan(int id)
    {
        var userIdResult = UserId;

        if (userIdResult.IsSucceeded)
        {
            var result = await _mediator.Send(new GetWeeklyPlanQuery(id, userIdResult.Value));

            return HandleResult(result);
        }

        return HandleResult(userIdResult);
    }

    [HttpGet("user")]
    public async Task<IActionResult> GetAllUserWeeklyPlans()
    {
        var userIdResult = UserId;

        if (userIdResult.IsSucceeded)
        {
            var result = await _mediator.Send(new GetAllUserWeeklyPlansQuery(userIdResult.Value));

            return HandleResult(result);
        }

        return HandleResult(userIdResult);
    }
}
