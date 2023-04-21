using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using MediatR;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates.Commands.DeleteWeeklyPlanTemplate;
public class DeleteWeeklyPlanTemplateCommandHandler : IRequestHandler<DeleteWeeklyPlanTemplateCommand>
{
    private readonly IWeeklyPlanTemplateRepository _weeklyPlanTemplateRepository;

    private readonly IUnitOfWork _unitOfWork;

    public DeleteWeeklyPlanTemplateCommandHandler(IWeeklyPlanTemplateRepository weeklyPlanTemplateRepository, IUnitOfWork unitOfWork)
    {
        _weeklyPlanTemplateRepository = weeklyPlanTemplateRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteWeeklyPlanTemplateCommand request, CancellationToken cancellationToken)
    {
        //TODO: Handle properly cascade deletion
        _weeklyPlanTemplateRepository.Remove(new WeeklyPlanTemplate() { Id = request.Id });

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
