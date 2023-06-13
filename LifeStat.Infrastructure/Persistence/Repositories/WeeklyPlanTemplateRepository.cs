using AutoMapper;
using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Shared;
using LifeStat.Domain.Shared.Errors;
using LifeStat.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeStat.Infrastructure.Persistence.Repositories;
internal class WeeklyPlanTemplateRepository : IWeeklyPlanTemplateRepository
{
    private readonly ApplicationDbContext _context;

    private readonly IMapper _mapper;

    public WeeklyPlanTemplateRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Result Add(WeeklyPlanTemplate weeklyPlanTemplate, int userId)
    {
        var dailyPlanTemplatesIds = weeklyPlanTemplate.DailyPlansTemplates.Select(dpt => dpt.Id).ToList();

        if (dailyPlanTemplatesIds.Count != 7)
        {
            return Result.FromError(
                new Error("Daily Plan Templates", $"Daily Plan Templates count must be 7 instead of {dailyPlanTemplatesIds.Count}."));
        }

        var user = _context.InnerUsers.Find(userId);

        if (user is null)
            return Result.FromError(new UserNotFoundError(userId));

        var dailyPlanTemplates = _context.DailyPlanTemplates
            .Where(dpt => dailyPlanTemplatesIds.Contains(dpt.Id) && dpt.UserId == userId).ToList();

        if (dailyPlanTemplates is null || dailyPlanTemplates.Count != dailyPlanTemplatesIds.Distinct().Count())
        {
            var retrievedIds = dailyPlanTemplates?.Select(dpt => dpt.Id)?.ToList() ?? new List<int>();

            var notFoundIds = dailyPlanTemplatesIds.Where(dptid => !retrievedIds.Contains(dptid)).ToList();

            var errors = notFoundIds.Select(id => new EntityNotFoundError(typeof(DailyPlanTemplate), id));

            return Result.FromErrors(errors);
        }

        var weeklyPlanTemplateDays = new List<WeeklyPlanTemplateDayDL>();

        for (int i = 1; i <= 7; i++)
        {
            weeklyPlanTemplateDays.Add(new WeeklyPlanTemplateDayDL()
            {
                DayOfWeek = (DayOfWeek)(i != 7 ? i : 0),
                DailyPlanTemplateId= dailyPlanTemplatesIds[i-1]
            });

        }

        var weeklyPlanTemplateDL = _mapper.Map<WeeklyPlanTemplateDL>(weeklyPlanTemplate);

        weeklyPlanTemplateDL.WeeklyPlanTemplateDays = weeklyPlanTemplateDays;

        weeklyPlanTemplateDL.UserId = userId;

        user.WeeklyPlanTemplates
            .Add(weeklyPlanTemplateDL);

        return Result.Good();
    }

    public async Task<Result<WeeklyPlanTemplate>> GetByIdAsync(int id, int userId)
    {
        var weeklyPlanTemplate = _mapper.Map<WeeklyPlanTemplate>(await _context.WeeklyPlanTemplates
            .AsNoTracking()
            .FirstOrDefaultAsync(wpt => wpt.Id == id && wpt.UserId == userId));

        if (weeklyPlanTemplate == null)
        {
            return Result<WeeklyPlanTemplate>.FromError(
                new EntityNotFoundError(typeof(WeeklyPlanTemplate), id));
        }

        return Result<WeeklyPlanTemplate>.Good(weeklyPlanTemplate);
    }

    public async Task<Result<WeeklyPlanTemplate>> GetByIdWithDailyPlanTemplatesAsync(int id, int userId)
    {
        var weeklyPlanTemplate = _mapper.Map<WeeklyPlanTemplate>(await _context
            .WeeklyPlanTemplates
            .Include(wpt => wpt.WeeklyPlanTemplateDays)
            .ThenInclude(wptd => wptd.DailyPlanTemplate)
            .AsNoTracking()
            .FirstOrDefaultAsync(wpt => wpt.Id == id && wpt.UserId == userId));

        if (weeklyPlanTemplate == null)
        {
            return Result<WeeklyPlanTemplate>.FromError(
                new EntityNotFoundError(typeof(WeeklyPlanTemplate), id));
        }

        return Result<WeeklyPlanTemplate>.Good(weeklyPlanTemplate);
    }


    public async Task<Result<List<WeeklyPlanTemplate>>> GetAllUserWeeklyPlanTemplatesAsync(int userId)
    {
        return Result<List<WeeklyPlanTemplate>>.Good(
            _mapper.Map<List<WeeklyPlanTemplate>>(await _context
                .WeeklyPlanTemplates
                .Where(wpt => wpt.UserId == userId && wpt.UserId == userId)
                .Include(wpt => wpt.WeeklyPlanTemplateDays)
                .ThenInclude(wptd => wptd.DailyPlanTemplate)
                .AsNoTracking()
                .ToListAsync()));
    }

    public Result Remove(WeeklyPlanTemplate weeklyPlanTemplate, int userId)
    {
        var weeklyPlanTemplateDL = _context.WeeklyPlanTemplates
            .FirstOrDefault(dpt => dpt.Id == weeklyPlanTemplate.Id && dpt.UserId == userId);

        if (weeklyPlanTemplateDL is null)
            return Result.FromError(
                new EntityNotFoundError(typeof(WeeklyPlanTemplate), weeklyPlanTemplate.Id));

        _context.WeeklyPlanTemplates.Remove(weeklyPlanTemplateDL);

        return Result.Good();
    }

    public Result Update(WeeklyPlanTemplate weeklyPlanTemplate, int userId)
    {
        var entity = _context.WeeklyPlanTemplates
            .Include(wpt => wpt.WeeklyPlanTemplateDays)
            .FirstOrDefault(wpt => wpt.Id == weeklyPlanTemplate.Id && wpt.UserId == userId);

        if (entity == null)
        {
            return Result.FromError(
                new EntityNotFoundError(typeof(WeeklyPlanTemplate), weeklyPlanTemplate.Id));
        }

        entity.Name = string.IsNullOrWhiteSpace(weeklyPlanTemplate.Name) ? entity.Name : weeklyPlanTemplate.Name;

        if (weeklyPlanTemplate.DailyPlansTemplates != null)
        {
            var zipped = weeklyPlanTemplate.DailyPlansTemplates.Zip(entity.WeeklyPlanTemplateDays);

            foreach (var pair in zipped)
            {
                WeeklyPlanTemplateDayDL weeklyPlanTemplateDay = pair.Second;
                DailyPlanTemplate inPlanTemplate = pair.First;

                weeklyPlanTemplateDay.DailyPlanTemplateId = inPlanTemplate.Id;
            }
        }

        _context.WeeklyPlanTemplates.Update(entity);

        return Result.Good();
    }
}
