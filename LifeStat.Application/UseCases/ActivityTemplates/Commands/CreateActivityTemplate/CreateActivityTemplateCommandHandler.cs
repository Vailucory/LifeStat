using Domain.Models;
using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.ActivityTemplates;
public class CreateActivityTemplateCommandHandler : ICommandHandler<CreateActivityTemplateCommand>
{
    private readonly IActivityTemplateRepository _activityTemplateRepository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateActivityTemplateCommandHandler(IActivityTemplateRepository activityTemplateRepository, IUnitOfWork unitOfWork)
    {
        _activityTemplateRepository = activityTemplateRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> Handle(CreateActivityTemplateCommand request, CancellationToken cancellationToken)
    {
        var activityTemplate = new ActivityTemplate() { 
            
            Name = request.Name, 
            Type = request.ActivityType 
        };

        return _activityTemplateRepository.Add(activityTemplate, request.UserId)
            .MergeFrom(await _unitOfWork.SaveChangesAsync(cancellationToken));
    }
}
