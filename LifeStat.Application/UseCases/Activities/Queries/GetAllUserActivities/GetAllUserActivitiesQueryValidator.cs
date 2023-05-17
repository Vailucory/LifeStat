using FluentValidation;

namespace LifeStat.Application.UseCases.Activities.Queries.GetAllUserActivities;
public class GetAllUserActivitiesQueryValidator : AbstractValidator<GetAllUserActivitiesQuery>
{
    public GetAllUserActivitiesQueryValidator()
    {
        RuleFor(x => x.UserId).GreaterThan(0);
    }
}
