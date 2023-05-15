using Domain.Models;
using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.DailyPlans.Commands.CreateDailyPlan;
public class CreateDailyPlanCommandHandler : ICommandHandler<CreateDailyPlanCommand>
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

    public async Task<Result> Handle(CreateDailyPlanCommand request, CancellationToken cancellationToken)
    {
        var activitiesResult = await _activityRepository.GetAllUserActivitiesFromTimeAsync(request.UserId, request.DailyPlanStart);

        var dailyPlan = new DailyPlan()
        {
            DailyPlanTemplate = new DailyPlanTemplate() { Id = request.DailyPlanTemplateId },
            FulfillmentStatus = request.FulfillmentStatus,
            Activities = activitiesResult.Value,
        };

        return _dailyPlanRepository.Add(dailyPlan, request.UserId)
            .MergeFrom(await _unitOfWork.SaveChangesAsync(cancellationToken));
    }
}
