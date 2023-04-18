using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using LifeStat.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LifeStat.Persistence;
public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseMySQL(connectionString);
        });

        services.AddAutoMapper(typeof(DependencyInjection));

        #region Adding Repositories
        services.AddScoped(typeof(IActivityRepository), typeof(ActivityRepository));

        services.AddScoped(typeof(IActivityTemplateRepository), typeof(ActivityTemplateRepository));

        services.AddScoped(typeof(IDailyPlanActivityDurationRepository), typeof(DailyPlanActivityDurationRepository));

        services.AddScoped(typeof(IDailyPlanRepository), typeof(DailyPlanRepository));

        services.AddScoped(typeof(IDailyPlanTemplateRepository), typeof(DailyPlanTemplateRepository));

        services.AddScoped(typeof(IUserRepository), typeof(UserRepository));

        services.AddScoped(typeof(IWeeklyPlanRepository), typeof(WeeklyPlanRepository));

        services.AddScoped(typeof(IWeeklyPlanTemplateRepository), typeof(WeeklyPlanTemplateRepository));
        #endregion

        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

        return services;
    }
}
