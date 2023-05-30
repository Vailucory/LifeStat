using Domain.Models;
using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.DailyPlanTemplates;
public class CreateDailyPlanTemplateCommandHandler : ICommandHandler<CreateDailyPlanTemplateCommand>
{
    private readonly IDailyPlanTemplateRepository _dailyPlanTemplateRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateDailyPlanTemplateCommandHandler(IDailyPlanTemplateRepository dailyPlanTemplateRepository, IUnitOfWork unitOfWork)
    {
        _dailyPlanTemplateRepository = dailyPlanTemplateRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateDailyPlanTemplateCommand request, CancellationToken cancellationToken)
    {
        var dailyPlanTemplate = new DailyPlanTemplate()
        {
            Name = request.Name,
            Activities = request.ActivityDurations
        };

        return _dailyPlanTemplateRepository.Add(dailyPlanTemplate, request.UserId)
            .MergeFrom(await _unitOfWork.SaveChangesAsync(cancellationToken));
    }
}
