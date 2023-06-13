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

    public async Task<Result<ActivityTemplate>> GetByIdAsync(int id, int userId)
    {
        var activityTemplate = _mapper.Map<ActivityTemplate>(await _context
            .ActivityTemplates
            .AsNoTracking()
            .FirstOrDefaultAsync(at => at.Id == id && at.UserId == userId));

        if (activityTemplate == null)
        {
            return Result<ActivityTemplate>.FromError(
                new EntityNotFoundError(typeof(ActivityTemplate), id));
        }

        return Result<ActivityTemplate>.Good(activityTemplate);
    }

    public async Task<Result<ActivityTemplate>> GetByIdWithActivitiesAsync(int id, int userId)
    {
        var activityTemplate = _mapper.Map<ActivityTemplate>(await _context
            .ActivityTemplates
            .Include(at => at.Activities)
            .AsNoTracking()
            .FirstOrDefaultAsync(at => at.Id == id && at.UserId == userId));

        if (activityTemplate == null)
        {
            return Result<ActivityTemplate>.FromError(
                new EntityNotFoundError(typeof(ActivityTemplate), id));
        }

        return Result<ActivityTemplate>.Good(activityTemplate);
    }

    public async Task<Result<List<ActivityTemplate>>> GetAllUserActivityTemplatesAsync(int userId)
    {
        return Result<List<ActivityTemplate>>.Good(
            _mapper.Map<List<ActivityTemplate>>(await _context
                .ActivityTemplates
                .Where(at => at.UserId == userId)
                .AsNoTracking()
                .ToListAsync()));
    }

    public Result Remove(ActivityTemplate activityTemplate, int userId)
    {
        var activityTemplateDL = _context.ActivityTemplates
            .FirstOrDefault(at => at.Id == activityTemplate.Id && at.UserId == userId);

        if (activityTemplateDL is null)
            return Result.FromError(
                new EntityNotFoundError(typeof(ActivityTemplate), activityTemplate.Id));

        _context.ActivityTemplates.Remove(activityTemplateDL);

        return Result.Good();
    }

    public Result Update(ActivityTemplate activityTemplate, int userId)
    {
        var entity = _context.ActivityTemplates
            .FirstOrDefault( at => at.Id == activityTemplate.Id && at.UserId == userId);

        if (entity == null)
        {
            return Result.FromError(
                new EntityNotFoundError(typeof(ActivityTemplate), activityTemplate.Id));
        }
        
        entity.Name = activityTemplate.Name;

        entity.Type = activityTemplate.Type;

        _context.ActivityTemplates.Update(entity);

        return Result.Good();
    }
}
