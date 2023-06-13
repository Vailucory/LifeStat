using Domain.Models;
using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.DailyPlanTemplates;
public class UpdateDailyPlanTemplateCommandHandler : ICommandHandler<UpdateDailyPlanTemplateCommand>
{
    private readonly IDailyPlanTemplateRepository _dailyPlanTemplateRepository;

    private readonly IUnitOfWork _unitOfWork;

    public UpdateDailyPlanTemplateCommandHandler(IDailyPlanTemplateRepository dailyPlanTemplateRepository, IUnitOfWork unitOfWork)
    {
        _dailyPlanTemplateRepository = dailyPlanTemplateRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateDailyPlanTemplateCommand request, CancellationToken cancellationToken)
    {
        DailyPlanTemplate template = new DailyPlanTemplate()
        {
            Id = request.DailyPlanTemplateId,
            Name = request.DailyPlanTemplateName,
            Activities = request.Activities
            .Select(dpad => new DailyPlanActivityDuration() 
            { 
                Duration = dpad.Duration, 
                ActivityTemplate = new ActivityTemplate() 
                { Id = dpad.ActivityTemplateId} 
            }).ToList(),
        };
        return _dailyPlanTemplateRepository.Update(template, request.UserId)
            .MergeFrom(await _unitOfWork.SaveChangesAsync(cancellationToken));
    }
}
