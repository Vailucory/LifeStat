using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using MediatR;

namespace LifeStat.Application.UseCases.DailyPlanTemplates.Commands.DeleteDailyPlanTemplate;
public class DeleteDailyPlanTemplateCommandHandler : IRequestHandler<DeleteDailyPlanTemplateCommand>
{
    private readonly IDailyPlanTemplateRepository _dailyPlanTemplateRepository;

    private readonly IUnitOfWork _unitOfWork;

    public DeleteDailyPlanTemplateCommandHandler(IDailyPlanTemplateRepository dailyPlanTemplateRepository, IUnitOfWork unitOfWork)
    {
        _dailyPlanTemplateRepository = dailyPlanTemplateRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteDailyPlanTemplateCommand request, CancellationToken cancellationToken)
    {
        //TODO: Handle properly cascade deletion and do not allow to delete if template used in WeeklyPlan templates 
        _dailyPlanTemplateRepository.Remove(new DailyPlanTemplate { Id = request.Id, });

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
