using LifeStat.Application.Interfaces;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Interfaces.UnitOfWork;
using LifeStat.Infrastructure.Identity;
using LifeStat.Infrastructure.Identity.Jwt;
using LifeStat.Infrastructure.Persistence;
using LifeStat.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LifeStat.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        #region Configuration
        var jwtConfigurationSection = configuration.GetSection("JwtSettings");

        services.Configure<JwtConfigurationSettings>(jwtConfigurationSection);

        JwtConfigurationSettings jwtConfigurationSettings = new JwtConfigurationSettings();

        jwtConfigurationSection.Bind(jwtConfigurationSettings);

        string connectionString = configuration.GetConnectionString("Database")!;
        #endregion

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

        services.AddScoped(typeof(IWeeklyPlanRepository), typeof(WeeklyPlanRepository));

        services.AddScoped(typeof(IWeeklyPlanTemplateRepository), typeof(WeeklyPlanTemplateRepository));
        #endregion

        services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

        #region Identity
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtConfigurationSettings.Issuer,
                    ValidAudience = jwtConfigurationSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfigurationSettings.Secret))
                };
            });

        var identityBuilder = services.AddIdentityCore<ApplicationUser>(setup =>
        {
            setup.User.RequireUniqueEmail = true;
            setup.Password.RequiredLength = 6;
            setup.Password.RequireUppercase = false;
            setup.Password.RequireLowercase = false;
            setup.Password.RequireNonAlphanumeric = false;
            setup.Password.RequireDigit = false;
        });

        identityBuilder = new IdentityBuilder(identityBuilder.UserType, typeof(ApplicationRole), services);

        identityBuilder
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders()
            .AddSignInManager<SignInManager<ApplicationUser>>();

        services.AddScoped<IJwtTokenAuthenticationService, JwtTokenAuthenticationService>();

        services.AddScoped<IIdentityService, IdentityService>();

        #endregion

        return services;
    }

    public static IApplicationBuilder UseInfrastructure(this IApplicationBuilder app)
    {
        app.UseAuthentication();

        app.UseAuthorization();

        return app;
    }
}
