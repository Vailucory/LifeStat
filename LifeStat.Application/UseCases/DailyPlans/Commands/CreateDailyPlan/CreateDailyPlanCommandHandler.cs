using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using MediatR;

namespace LifeStat.Application.UseCases.DailyPlans.Commands.CreateDailyPlan;
public class CreateDailyPlanCommandHandler : IRequestHandler<CreateDailyPlanCommand>
{
    private readonly IDailyPlanRepository _dailyPlanRepository;

    private readonly IUnitOfWork _unitOfWork;

    private readonly IActivityRepository _activityRepository;

    public CreateDailyPlanCommandHandler(
        IDailyPlanRepository dailyPlanRepository, 
        IUnitOfWork unitOfWork, 
        IActivityRepository activityRepository)
    {
        _dailyPlanRepository = dailyPlanRepository;
        _unitOfWork = unitOfWork;
        _activityRepository = activityRepository;
    }

    public async Task Handle(CreateDailyPlanCommand request, CancellationToken cancellationToken)
    {
        var activities = await _activityRepository.GetAllUserActivitiesFromTimeAsync(request.UserId, request.DailyPlanStart);

        var dailyPlan = new DailyPlan()
        {
            DailyPlanTemplate = new DailyPlanTemplate() { Id = request.DailyPlanTemplateId },
            FulfillmentStatus = request.FulfillmentStatus,
            Activities = activities,
        };

        _dailyPlanRepository.Add(dailyPlan, request.UserId);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
