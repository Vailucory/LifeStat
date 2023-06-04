using AutoMapper;
using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Shared;
using LifeStat.Domain.Shared.Errors;
using LifeStat.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeStat.Infrastructure.Persistence.Repositories;
public class DailyPlanTemplateRepository : IDailyPlanTemplateRepository
{
    private readonly ApplicationDbContext _context;

    private readonly IMapper _mapper;

    public DailyPlanTemplateRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Result Add(DailyPlanTemplate dailyPlanTemplate, int userId)
    {
        var user = _context.InnerUsers.Find(userId);

        if (user is null)
            return Result.FromError(new UserNotFoundError(userId));

        user.DailyPlanTemplates
            .Add(_mapper.Map<DailyPlanTemplateDL>(dailyPlanTemplate));

        return Result.Good();
    }

    public async Task<Result<DailyPlanTemplate>> GetByIdAsync(int id)
    {
        var dailyPlanTemplate = _mapper.Map<DailyPlanTemplate>(await _context.DailyPlanTemplates
            .FindAsync(id));

        if (dailyPlanTemplate == null)
        {
            return Result<DailyPlanTemplate>.FromError(
                new EntityNotFoundError(typeof(DailyPlanTemplate), id));
        }

        return Result<DailyPlanTemplate>.Good(dailyPlanTemplate);
    }

    public async Task<Result<DailyPlanTemplate>> GetByIdWithActivityDurationsAsync(int id)
    {
        var dailyPlanTemplate = _mapper.Map<DailyPlanTemplate>(await _context
            .DailyPlanTemplates
            .Include(dpt => dpt.Activities)
            .FirstOrDefaultAsync(dpt => dpt.Id == id));

        if (dailyPlanTemplate == null)
        {
            return Result<DailyPlanTemplate>.FromError(
                new EntityNotFoundError(typeof(DailyPlanTemplate), id));
        }

        return Result<DailyPlanTemplate>.Good(dailyPlanTemplate);
    }

    public async Task<Result<DailyPlanTemplate>> GetByIdWithDailyPlansAsync(int id)
    {
        var dailyPlanTemplate = _mapper.Map<DailyPlanTemplate>(await _context
            .DailyPlanTemplates
            .Include(dpt => dpt.DailyPlans)
            .FirstOrDefaultAsync(dpt => dpt.Id == id));

        if (dailyPlanTemplate == null)
        {
            return Result<DailyPlanTemplate>.FromError(
                new EntityNotFoundError(typeof(DailyPlanTemplate), id));
        }

        return Result<DailyPlanTemplate>.Good(dailyPlanTemplate);
    }

    public async Task<Result<List<DailyPlanTemplate>>> GetAllUserDailyPlanTemplatesAsync(int userId)
    {
        return Result<List<DailyPlanTemplate>>.Good(
            _mapper.Map<List<DailyPlanTemplate>>(await _context
                .DailyPlanTemplates
                .Where(dpt => dpt.UserId == userId)
                .ToListAsync()));
    }

    public Result Remove(DailyPlanTemplate dailyPlanTemplate)
    {
        _context.DailyPlanTemplates.Remove(_mapper.Map<DailyPlanTemplateDL>(dailyPlanTemplate));

        return Result.Good();
    }
    
    public Result Update(DailyPlanTemplate dailyPlanTemplate)
    {
        var entity = _context.DailyPlanTemplates
            .Include(dpt => dpt.Activities)
            .Where(dpt => dpt.Id == dailyPlanTemplate.Id)
            .FirstOrDefault();

        if (entity == null)
        {
            return Result.FromError(
                new EntityNotFoundError(typeof(DailyPlanTemplate), dailyPlanTemplate.Id));
        }

        entity.Name = dailyPlanTemplate.Name;

        if (dailyPlanTemplate.Activities != null)
        {
            var zipped = dailyPlanTemplate.Activities.Zip(entity.Activities);

            foreach (var pair in zipped)
            {
                DailyPlanActivityDurationDL dbActivity = pair.Second;
                DailyPlanActivityDuration inActivity = pair.First;

                dbActivity.Duration = inActivity.Duration;

                dbActivity.ActivityTemplateId = inActivity.ActivityTemplate.Id;

                dbActivity.DailyPlanTemplateId = inActivity.DailyPlanTemplate.Id;
            }
        }

        _context.DailyPlanTemplates.Update(entity);


        return Result.Good();
    }
}
