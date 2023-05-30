using FluentValidation;

namespace LifeStat.Application.UseCases.Activities;
public class GetActivitiesByTemplateIdQueryValidator : AbstractValidator<GetActivitiesByTemplateIdQuery>
{
    public GetActivitiesByTemplateIdQueryValidator()
    {
        RuleFor(x => x.TemplateId).GreaterThan(0);
    }
}
