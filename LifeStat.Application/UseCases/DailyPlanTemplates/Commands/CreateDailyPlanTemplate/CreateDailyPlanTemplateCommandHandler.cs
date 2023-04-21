using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using MediatR;

namespace LifeStat.Application.UseCases.DailyPlanTemplates.Commands.CreateDailyPlanTemplate;
public class CreateDailyPlanTemplateCommandHandler : IRequestHandler<CreateDailyPlanTemplateCommand>
{
    private readonly IDailyPlanTemplateRepository _dailyPlanTemplateRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateDailyPlanTemplateCommandHandler(IDailyPlanTemplateRepository dailyPlanTemplateRepository, IUnitOfWork unitOfWork)
    {
        _dailyPlanTemplateRepository = dailyPlanTemplateRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateDailyPlanTemplateCommand request, CancellationToken cancellationToken)
    {
        var dailyPlanTemplate = new DailyPlanTemplate()
        {
            Name = request.Name,
            Activities = request.ActivityDurations
        };

        _dailyPlanTemplateRepository.Add(dailyPlanTemplate, request.UserId);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
