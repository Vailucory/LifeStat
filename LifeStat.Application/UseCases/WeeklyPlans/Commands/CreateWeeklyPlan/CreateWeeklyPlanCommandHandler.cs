using Domain.Models;
using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.WeeklyPlans.Commands.CreateWeeklyPlan;
public class CreateWeeklyPlanCommandHandler : ICommandHandler<CreateWeeklyPlanCommand>
{
    private readonly IWeeklyPlanRepository _weeklyPlanRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateWeeklyPlanCommandHandler(IWeeklyPlanRepository weeklyPlanRepository, IUnitOfWork unitOfWork)
    {
        _weeklyPlanRepository = weeklyPlanRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateWeeklyPlanCommand request, CancellationToken cancellationToken)
    {
        var weeklyPlan = new WeeklyPlan()
        {
            WeeklyPlanTemplate = new WeeklyPlanTemplate() { Id = request.WeeklyPlanTemplateId },
            FulfillmentStatus = request.FulfillmentStatus, 
        };

        return _weeklyPlanRepository.Add(weeklyPlan, request.UserId)
            .MergeFrom(await _unitOfWork.SaveChangesAsync(cancellationToken));
    }
}
