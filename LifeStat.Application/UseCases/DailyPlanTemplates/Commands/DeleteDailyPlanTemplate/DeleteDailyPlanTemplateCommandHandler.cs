using Domain.Models;
using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.DailyPlanTemplates.Commands.DeleteDailyPlanTemplate;
public class DeleteDailyPlanTemplateCommandHandler : ICommandHandler<DeleteDailyPlanTemplateCommand>
{
    private readonly IDailyPlanTemplateRepository _dailyPlanTemplateRepository;

    private readonly IUnitOfWork _unitOfWork;

    public DeleteDailyPlanTemplateCommandHandler(IDailyPlanTemplateRepository dailyPlanTemplateRepository, IUnitOfWork unitOfWork)
    {
        _dailyPlanTemplateRepository = dailyPlanTemplateRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteDailyPlanTemplateCommand request, CancellationToken cancellationToken)
    {
        //TODO: Handle properly cascade deletion and do not allow to delete if template used in WeeklyPlan templates 
       return _dailyPlanTemplateRepository.Remove(new DailyPlanTemplate { Id = request.Id, })
            .MergeFrom(await _unitOfWork.SaveChangesAsync(cancellationToken));
    }
}
