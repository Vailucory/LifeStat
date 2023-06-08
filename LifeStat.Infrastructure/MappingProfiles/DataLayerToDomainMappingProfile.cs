using AutoMapper;
using Domain.Models;
using LifeStat.Infrastructure.Persistence.Models;

namespace LifeStat.Persistence.MappingProfiles;
internal class DataLayerToDomainMappingProfile : Profile
{
    public DataLayerToDomainMappingProfile()
    {
        MapActivity();

        MapActivityTemplate();

        MapDailyPlanActivityDuration();

        MapDailyPlan();

        MapDailyPlanTemplate();

        MapUser();

        MapWeeklyPlan();

        MapWeeklyPlanTemplate();
    }

    
    private void MapActivity()
    {
        CreateMap<Activity, ActivityDL>();

        CreateMap<ActivityDL, Activity>();
    }

    private void MapActivityTemplate()
    {
        CreateMap<ActivityTemplate, ActivityTemplateDL>();

        CreateMap<ActivityTemplateDL, ActivityTemplate>();
    }

    private void MapDailyPlanActivityDuration()
    {
        CreateMap<DailyPlanActivityDuration, DailyPlanActivityDurationDL>();

        CreateMap<DailyPlanActivityDurationDL, DailyPlanActivityDuration>();
    }

    private void MapDailyPlan()
    {
        CreateMap<DailyPlan, DailyPlanDL>();

        CreateMap<DailyPlanDL, DailyPlan>();
    }

    private void MapDailyPlanTemplate()
    {
        CreateMap<DailyPlanTemplate, DailyPlanTemplateDL>();

        CreateMap<DailyPlanTemplateDL, DailyPlanTemplate>();
    }

    private void MapUser()
    {
        CreateMap<User, UserDL>();

        CreateMap<UserDL, User>();
    }

    private void MapWeeklyPlan()
    {
        CreateMap<WeeklyPlan, WeeklyPlanDL>();

        CreateMap<WeeklyPlanDL, WeeklyPlan>();
    }

    private void MapWeeklyPlanTemplate()
    {
        CreateMap <WeeklyPlanTemplate, WeeklyPlanTemplateDL > ();

        CreateMap<WeeklyPlanTemplateDL, WeeklyPlanTemplate>()
            .ForMember(dest => dest.DailyPlansTemplates, opt => opt
            .MapFrom(src => src.WeeklyPlanTemplateDays
            .Select(wptdp => wptdp.DailyPlanTemplate)
            .ToList()));
    }
}
