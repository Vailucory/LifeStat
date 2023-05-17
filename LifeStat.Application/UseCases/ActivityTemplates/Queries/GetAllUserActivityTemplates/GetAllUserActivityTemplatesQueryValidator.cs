using FluentValidation;

namespace LifeStat.Application.UseCases.ActivityTemplates.Queries.GetAllUserActivityTemplates;
public class GetAllUserActivityTemplatesQueryValidator : AbstractValidator<GetAllUserActivityTemplatesQuery>
{
    public GetAllUserActivityTemplatesQueryValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
    }
}
