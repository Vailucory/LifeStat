using AutoMapper;
using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Shared;
using LifeStat.Domain.Shared.Errors;
using LifeStat.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeStat.Infrastructure.Persistence.Repositories;
public class DailyPlanActivityDurationRepository : IDailyPlanActivityDurationRepository
{
    private readonly ApplicationDbContext _context;

    private readonly IMapper _mapper;

    public DailyPlanActivityDurationRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Result Add(DailyPlanActivityDuration dailyPlanActivityDuration, int userId)
    {
        var user = _context.InnerUsers
            .Include(u => u.ActivityTemplates)
            .Include(u => u.DailyPlanTemplates)
            .FirstOrDefault(x => x.Id == userId);

        if (user is null)
            return Result.FromError(new UserNotFoundError(userId));

        var activityTemplate = user.ActivityTemplates
            .FirstOrDefault(at => at.UserId == userId && at.Id == dailyPlanActivityDuration.ActivityTemplate.Id);

        if (activityTemplate is null)
            return Result.FromError(new EntityNotFoundError(typeof(ActivityTemplate), dailyPlanActivityDuration.ActivityTemplate.Id));
        

        var dailyPlanTemplate = user.DailyPlanTemplates
            .FirstOrDefault(dpt => dpt.UserId == userId && dpt.Id == dailyPlanActivityDuration.DailyPlanTemplate.Id);

        if (dailyPlanTemplate is null)
            return Result.FromError(new EntityNotFoundError(typeof(DailyPlanTemplate), dailyPlanActivityDuration.DailyPlanTemplate.Id));

        var dailyPlanActivityDurationDL = _mapper.Map<DailyPlanActivityDurationDL>(dailyPlanActivityDuration);

        dailyPlanActivityDurationDL.DailyPlanTemplate = dailyPlanTemplate;

        dailyPlanActivityDurationDL.ActivityTemplate = activityTemplate;

        _context.DailyPlanActivityDurations.Add(dailyPlanActivityDurationDL);

        return Result.Good();
    }

    public async Task<Result<DailyPlanActivityDuration>> GetByIdAsync(int id, int userId)
    {
        var dailyPlanActivityDuration = _mapper.Map<DailyPlanActivityDuration>(await _context
            .DailyPlanActivityDurations
            .AsNoTracking()
            .FirstOrDefaultAsync(dpad => dpad.Id == id));

        if (dailyPlanActivityDuration == null)
        {
            return Result<DailyPlanActivityDuration>.FromError(
                new EntityNotFoundError(typeof(DailyPlanActivityDuration), id));
        }

        return Result<DailyPlanActivityDuration>.Good(dailyPlanActivityDuration);
    }

    public Result Remove(DailyPlanActivityDuration dailyPlanActivityDuration, int userId)
    {
        var dailyPlanActivityDurationDL = _context.DailyPlanActivityDurations
            .Include(dpad => dpad.DailyPlanTemplate)
            .Include(dpad => dpad.ActivityTemplate)
            .FirstOrDefault(dpad => dpad.Id == dailyPlanActivityDuration.Id
                && dpad.ActivityTemplate.UserId == userId
                && dpad.DailyPlanTemplate.UserId == userId);

        if (dailyPlanActivityDurationDL is null)
            return Result.FromError(
                new EntityNotFoundError(typeof(DailyPlanActivityDurationDL), dailyPlanActivityDuration.Id));

        _context.DailyPlanActivityDurations
            .Remove(dailyPlanActivityDurationDL);

        return Result.Good();
    }

    public Result Update(DailyPlanActivityDuration dailyPlanActivityDuration, int userId)
    {
        var entity = _context.DailyPlanActivityDurations
            .Include(dpad => dpad.DailyPlanTemplate)
            .Include(dpad => dpad.ActivityTemplate)
            .FirstOrDefault(dpad => dpad.Id == dailyPlanActivityDuration.Id 
                && dpad.ActivityTemplate.UserId == userId 
                && dpad.DailyPlanTemplate.UserId == userId);

        if (entity == null)
        {
            return Result.FromError(
                new EntityNotFoundError(typeof(DailyPlanActivityDuration), dailyPlanActivityDuration.Id));
        }

        entity.Duration = dailyPlanActivityDuration.Duration;

        entity.ActivityTemplateId = dailyPlanActivityDuration.ActivityTemplate.Id;

        entity.DailyPlanTemplateId = dailyPlanActivityDuration.DailyPlanTemplate.Id;

        _context.DailyPlanActivityDurations.Update(entity);

        return Result.Good();
    }

}
