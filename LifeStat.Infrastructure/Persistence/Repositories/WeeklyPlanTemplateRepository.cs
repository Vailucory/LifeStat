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
        var user = _context.InnerUsers.Find(userId);

        if (user is null)
            return Result.FromError(new UserNotFoundError(userId));

        user.WeeklyPlanTemplates
            .Add(_mapper.Map<WeeklyPlanTemplateDL>(weeklyPlanTemplate));

        return Result.Good();
    }

    public async Task<Result<WeeklyPlanTemplate>> GetByIdAsync(int id)
    {
        var weeklyPlanTemplate = _mapper.Map<WeeklyPlanTemplate>(await _context.WeeklyPlanTemplates
            .FindAsync(id));

        if (weeklyPlanTemplate == null)
        {
            return Result<WeeklyPlanTemplate>.FromError(
                new EntityNotFoundError(typeof(WeeklyPlanTemplate), id));
        }

        return Result<WeeklyPlanTemplate>.Good(weeklyPlanTemplate);
    }

    public async Task<Result<WeeklyPlanTemplate>> GetByIdWithDailyPlanTemplatesAsync(int id)
    {
        var weeklyPlanTemplate = _mapper.Map<WeeklyPlanTemplate>(await _context
            .WeeklyPlanTemplates
            .Include(wpt => wpt.DailyPlansTemplates)
            .FirstOrDefaultAsync(wpt => wpt.Id == id));

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
                .Where(wpt => wpt.UserId == userId)
                .ToListAsync()));
    }

    public Result Remove(WeeklyPlanTemplate weeklyPlanTemplate)
    {
        _context.WeeklyPlanTemplates.Remove(_mapper.Map<WeeklyPlanTemplateDL>(weeklyPlanTemplate));

        return Result.Good();
    }

    public Result Update(WeeklyPlanTemplate weeklyPlanTemplate)
    {
        var entity = _context.WeeklyPlanTemplates.Find(weeklyPlanTemplate.Id);

        if (entity == null)
        {
            return Result.FromError(
                new EntityNotFoundError(typeof(WeeklyPlanTemplate), weeklyPlanTemplate.Id));
        }

        entity.Name = weeklyPlanTemplate.Name;

        if (weeklyPlanTemplate.DailyPlansTemplates != null)
        {
            var zipped = weeklyPlanTemplate.DailyPlansTemplates.Zip(entity.DailyPlansTemplates);

            foreach (var pair in zipped)
            {
                DailyPlanTemplateDL dbPlanTemplate = pair.Second;
                DailyPlanTemplate inPlanTemplate = pair.First;

                dbPlanTemplate.Id = inPlanTemplate.Id;

                dbPlanTemplate.Name = inPlanTemplate.Name;

            }
        }

        _context.WeeklyPlanTemplates.Update(entity);

        return Result.Good();
    }
}
