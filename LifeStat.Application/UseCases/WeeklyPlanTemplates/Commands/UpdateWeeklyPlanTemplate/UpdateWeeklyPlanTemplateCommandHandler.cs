using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using MediatR;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates.Commands.UpdateWeeklyPlanTemplate;
public class UpdateWeeklyPlanTemplateCommandHandler : IRequestHandler<UpdateWeeklyPlanTemplateCommand>
{
    private readonly IWeeklyPlanTemplateRepository _weeklyPlanTemplateRepository;

    private readonly IUnitOfWork _unitOfWork;

    public UpdateWeeklyPlanTemplateCommandHandler(IWeeklyPlanTemplateRepository weeklyPlanTemplateRepository, IUnitOfWork unitOfWork)
    {
        _weeklyPlanTemplateRepository = weeklyPlanTemplateRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateWeeklyPlanTemplateCommand request, CancellationToken cancellationToken)
    {
        _weeklyPlanTemplateRepository.Update(request.WeeklyPlanTemplate);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
