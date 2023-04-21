using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using MediatR;

namespace LifeStat.Application.UseCases.DailyPlanTemplates.Commands.UpdateDailyPlanTemplate;
public class UpdateDailyPlanTemplateCommandHandler : IRequestHandler<UpdateDailyPlanTemplateCommand>
{
    private readonly IDailyPlanTemplateRepository _dailyPlanTemplateRepository;

    private readonly IUnitOfWork _unitOfWork;

    public UpdateDailyPlanTemplateCommandHandler(IDailyPlanTemplateRepository dailyPlanTemplateRepository, IUnitOfWork unitOfWork)
    {
        _dailyPlanTemplateRepository = dailyPlanTemplateRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(UpdateDailyPlanTemplateCommand request, CancellationToken cancellationToken)
    {
        _dailyPlanTemplateRepository.Update(request.DailyPlanTemplate); 

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
