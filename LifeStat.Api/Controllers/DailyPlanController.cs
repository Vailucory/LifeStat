using LifeStat.Application.UseCases.DailyPlans;
using LifeStat.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LifeStat.Api.Controllers;
[Route("api/daily-plans")]
[ApiController]
[Authorize]
public class DailyPlanController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public DailyPlanController(IMediator mediator, ICurrentUserIdProvider currentUserIdProvider) : base(currentUserIdProvider)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDailyPlan(CreateDailyPlanCommand command)
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
    public async Task<IActionResult> GetDailyPlan(int id)
    {
        var userIdResult = UserId;

        if (userIdResult.IsSucceeded)
        {
            var result = await _mediator.Send(new GetDailyPlanQuery(id, userIdResult.Value));

            return HandleResult(result);
        }

        return HandleResult(userIdResult);
    }

    [HttpGet("user")]
    public async Task<IActionResult> GetAllUserDailyPlans()
    {
        var userIdResult = UserId;

        if (userIdResult.IsSucceeded)
        {
            var result = await _mediator.Send(new GetAllUserDailyPlansQuery(userIdResult.Value));

            return HandleResult(result);
        }

        return HandleResult(userIdResult);
    }
}
