using Domain.Models;
using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.WeeklyPlanTemplates;
public class DeleteWeeklyPlanTemplateCommandHandler : ICommandHandler<DeleteWeeklyPlanTemplateCommand>
{
    private readonly IWeeklyPlanTemplateRepository _weeklyPlanTemplateRepository;

    private readonly IUnitOfWork _unitOfWork;

    public DeleteWeeklyPlanTemplateCommandHandler(IWeeklyPlanTemplateRepository weeklyPlanTemplateRepository, IUnitOfWork unitOfWork)
    {
        _weeklyPlanTemplateRepository = weeklyPlanTemplateRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteWeeklyPlanTemplateCommand request, CancellationToken cancellationToken)
    {
        //TODO: Handle properly cascade deletion
        return _weeklyPlanTemplateRepository.Remove(new WeeklyPlanTemplate() { Id = request.Id }, request.UserId)
            .MergeFrom(await _unitOfWork.SaveChangesAsync(cancellationToken));
    }
}
