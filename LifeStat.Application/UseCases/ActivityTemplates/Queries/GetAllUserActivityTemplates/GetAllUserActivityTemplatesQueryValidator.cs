using FluentValidation;

namespace LifeStat.Application.UseCases.ActivityTemplates;
public class GetAllUserActivityTemplatesQueryValidator : AbstractValidator<GetAllUserActivityTemplatesQuery>
{
    public GetAllUserActivityTemplatesQueryValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
    }
}
