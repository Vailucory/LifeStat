using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.UseCases.ActivityTemplates;
public class UpdateActivityTemplateCommandHandler : ICommandHandler<UpdateActivityTemplateCommand>
{
    private readonly IActivityTemplateRepository _activityTemplateRepository;

    private readonly IUnitOfWork _unitOfWork;

    public UpdateActivityTemplateCommandHandler(IActivityTemplateRepository activityTemplateRepository, IUnitOfWork unitOfWork)
    {
        _activityTemplateRepository = activityTemplateRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdateActivityTemplateCommand request, CancellationToken cancellationToken)
    {
        return _activityTemplateRepository.Update(request.ActivityTemplate, request.UserId)
            .MergeFrom(await _unitOfWork.SaveChangesAsync(cancellationToken));
    }
}
