using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeStat.Application.UseCases.WeeklyPlans.Commands.CreateWeeklyPlan;
public class CreateWeeklyPlanCommandHandler : IRequestHandler<CreateWeeklyPlanCommand>
{
    private readonly IWeeklyPlanRepository _weeklyPlanRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateWeeklyPlanCommandHandler(IWeeklyPlanRepository weeklyPlanRepository, IUnitOfWork unitOfWork)
    {
        _weeklyPlanRepository = weeklyPlanRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateWeeklyPlanCommand request, CancellationToken cancellationToken)
    {
        var weeklyPlan = new WeeklyPlan()
        {
            WeeklyPlanTemplate = new WeeklyPlanTemplate() { Id = request.WeeklyPlanTemplateId },
            FulfillmentStatus = request.FulfillmentStatus, 
        };

        _weeklyPlanRepository.Add(weeklyPlan, request.UserId);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
