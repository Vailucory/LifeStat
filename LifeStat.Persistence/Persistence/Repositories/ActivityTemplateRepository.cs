using AutoMapper;
using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Shared;
using LifeStat.Domain.Shared.Errors;
using LifeStat.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeStat.Infrastructure.Persistence.Repositories;
public class ActivityTemplateRepository : IActivityTemplateRepository
{
    private readonly ApplicationDbContext _context;

    private readonly IMapper _mapper;

    public ActivityTemplateRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Result Add(ActivityTemplate activityTemplate, int userId)
    {
        var user = _context.InnerUsers.Find(userId);

        if (user is null)
            return Result.FromError(new UserNotFoundError(userId));

        user.ActivityTemplates
            .Add(_mapper.Map<ActivityTemplateDL>(activityTemplate));

        return Result.Good();
    }

    public async Task<Result<ActivityTemplate>> GetByIdAsync(int id)
    {
        var activityTemplate = _mapper.Map<ActivityTemplate>(await _context
            .ActivityTemplates
            .FindAsync(id));

        if (activityTemplate == null)
        {
            return Result<ActivityTemplate>.FromError(
                new EntityNotFoundError(typeof(Activity), id));
        }

        return Result<ActivityTemplate>.Good(activityTemplate);
    }

    public async Task<Result<ActivityTemplate>> GetByIdWithActivitiesAsync(int id)
    {
        var activityTemplate = _mapper.Map<ActivityTemplate>(await _context
            .ActivityTemplates
            .Include(at => at.Activities)
            .FirstOrDefaultAsync(at => at.Id == id));

        if (activityTemplate == null)
        {
            return Result<ActivityTemplate>.FromError(
                new EntityNotFoundError(typeof(Activity), id));
        }

        return Result<ActivityTemplate>.Good(activityTemplate);
    }

    public async Task<Result<List<ActivityTemplate>>> GetAllUserActivityTemplatesAsync(int userId)
    {
        return Result<List<ActivityTemplate>>.Good(
            _mapper.Map<List<ActivityTemplate>>(await _context
                .ActivityTemplates
                .Where(at => at.UserId == userId)
                .ToListAsync()));
    }

    public Result Remove(ActivityTemplate activityTemplate)
    {
        _context.ActivityTemplates.Remove(_mapper.Map<ActivityTemplateDL>(activityTemplate));

        return Result.Good();
    }

    public Result Update(ActivityTemplate activityTemplate)
    {
        _context.ActivityTemplates.Update(_mapper.Map<ActivityTemplateDL>(activityTemplate));

        return Result.Good();
    }
}
