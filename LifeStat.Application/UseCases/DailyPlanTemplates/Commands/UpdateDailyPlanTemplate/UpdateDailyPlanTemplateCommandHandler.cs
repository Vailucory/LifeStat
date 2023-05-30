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
        return _dailyPlanTemplateRepository.Update(request.DailyPlanTemplate)
            .MergeFrom(await _unitOfWork.SaveChangesAsync(cancellationToken));
    }
}
