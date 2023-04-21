using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using MediatR;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates.Commands.CreateWeeklyPlanTemplate;
public class CreateWeeklyPlanTemplateCommandHandler : IRequestHandler<CreateWeeklyPlanTemplateCommand>
{
    private readonly IWeeklyPlanTemplateRepository _weeklyPlanTemplateRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateWeeklyPlanTemplateCommandHandler(IWeeklyPlanTemplateRepository weeklyPlanTemplateRepository, IUnitOfWork unitOfWork)
    {
        _weeklyPlanTemplateRepository = weeklyPlanTemplateRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateWeeklyPlanTemplateCommand request, CancellationToken cancellationToken)
    {
        var weeklyPlanTemplate = new WeeklyPlanTemplate()
        {
            Name = request.Name,
            DailyPlansTemplates = request.DailyPlanTemplates
        };

        _weeklyPlanTemplateRepository.Add(weeklyPlanTemplate, request.UserId);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
