using FluentValidation;

namespace LifeStat.Application.UseCases.ActivityTemplates;
public class GetActivityTemplateQueryValidator : AbstractValidator<GetActivityTemplateQuery>
{
    public GetActivityTemplateQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
