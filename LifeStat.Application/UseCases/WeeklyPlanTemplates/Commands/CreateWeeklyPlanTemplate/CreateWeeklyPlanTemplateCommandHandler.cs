using Domain.Models;
using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates;
public class CreateWeeklyPlanTemplateCommandHandler : ICommandHandler<CreateWeeklyPlanTemplateCommand>
{
    private readonly IWeeklyPlanTemplateRepository _weeklyPlanTemplateRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateWeeklyPlanTemplateCommandHandler(IWeeklyPlanTemplateRepository weeklyPlanTemplateRepository, IUnitOfWork unitOfWork)
    {
        _weeklyPlanTemplateRepository = weeklyPlanTemplateRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateWeeklyPlanTemplateCommand request, CancellationToken cancellationToken)
    {
        var weeklyPlanTemplate = new WeeklyPlanTemplate()
        {
            Name = request.Name,
            DailyPlansTemplates = request.DailyPlanTemplates
        };

        return _weeklyPlanTemplateRepository.Add(weeklyPlanTemplate, request.UserId)
            .MergeFrom(await _unitOfWork.SaveChangesAsync(cancellationToken));
    }
}
