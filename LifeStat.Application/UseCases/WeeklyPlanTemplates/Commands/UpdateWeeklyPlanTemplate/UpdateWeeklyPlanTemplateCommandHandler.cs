using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates.Commands.UpdateWeeklyPlanTemplate;
public class UpdateWeeklyPlanTemplateCommandHandler : ICommandHandler<UpdateWeeklyPlanTemplateCommand>
{
    private readonly IWeeklyPlanTemplateRepository _weeklyPlanTemplateRepository;

    private readonly IUnitOfWork _unitOfWork;

    public UpdateWeeklyPlanTemplateCommandHandler(IWeeklyPlanTemplateRepository weeklyPlanTemplateRepository, IUnitOfWork unitOfWork)
    {
        _weeklyPlanTemplateRepository = weeklyPlanTemplateRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateWeeklyPlanTemplateCommand request, CancellationToken cancellationToken)
    {
        return _weeklyPlanTemplateRepository.Update(request.WeeklyPlanTemplate)
            .MergeFrom(await _unitOfWork.SaveChangesAsync(cancellationToken));
    }
}
