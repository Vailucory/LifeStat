using AutoMapper;
using Domain.Models;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Domain.Shared;
using LifeStat.Domain.Shared.Errors;
using LifeStat.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeStat.Infrastructure.Persistence.Repositories;
public class ActivityRepository : IActivityRepository
{
    private readonly ApplicationDbContext _context;

    private readonly IMapper _mapper;

    public ActivityRepository(
        ApplicationDbContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Result Add(Activity activity, int userId)
    {
        var user = _context.InnerUsers.Find(userId);

        if (user is null)
            return Result.FromError(new UserNotFoundError(userId));

        var activityTemplate = _context.ActivityTemplates.Find(activity.Template.Id);

        if (activityTemplate is null)
            return Result.FromError(new EntityNotFoundError(typeof(ActivityTemplate), activity.Template.Id));

        var activityDL = _mapper.Map<ActivityDL>(activity);

        activityDL.Template = activityTemplate;

        activityDL.UserId = userId;

        user.Activities.Add(activityDL);

        return Result.Good();
    }

    public async Task<Result<Activity>> GetByIdAsync(int id, int userId)
    {
        var activity = await _context.Activities.AsNoTracking().FirstOrDefaultAsync(a => a.Id == id && a.UserId == userId);

        if (activity is null)
        {
            return Result<Activity>.FromError(
                new EntityNotFoundError(typeof(Activity), id));
        }

        return Result<Activity>.Good(_mapper.Map<Activity>(activity));
    }

    public async Task<Result<List<Activity>>> GetAllUserActivitiesAsync(int userId)
    {

        return Result<List<Activity>>.Good(
            _mapper.Map<List<Activity>>(await _context
                .Activities
                .Where(a => a.UserId == userId)
                .AsNoTracking()
                .ToListAsync()));
    }

    public async Task<Result<List<Activity>>> GetAllUserActivitiesFromTimeAsync(int userId, DateTime fromTime)
    {
        return Result<List<Activity>>.Good(
            _mapper.Map<List<Activity>>(await _context
                .Activities
                .Include(a => a.Template)
                .Where(a => a.UserId == userId && a.StartTimeLocal >= fromTime)
                .AsNoTracking()
                .ToListAsync()));
    }

    public async Task<Result<List<Activity>>> GetActivitiesByTemplateIdAsync(int templateId, int userId)
    {
        return Result<List<Activity>>.Good(
            _mapper.Map<List<Activity>>(await _context
                .Activities
                .Where(a => a.ActivityTemplateId == templateId && a.UserId == userId)
                .AsNoTracking()
                .ToListAsync()));
    }

    public Result Remove(Activity activity, int userId)
    {
        var activityDL = _context.Activities.FirstOrDefault(a => a.Id == activity.Id && a.UserId == userId);

        if (activityDL is null)
            return Result.FromError(
                new EntityNotFoundError(typeof(Activity), activity.Id));

        _context.Activities.Remove(_mapper.Map<ActivityDL>(activity));

        return Result.Good();
    }

    public Result Update(Activity activity, int userId)
    {
        var entity = _context.Activities.FirstOrDefault(a => a.Id == activity.Id && a.UserId == userId);

        if (entity == null)
        {
            return Result.FromError(
                new EntityNotFoundError(typeof(Activity), activity.Id));
        }

        entity.StartTimeLocal = activity.StartTimeLocal;

        entity.EndTimeLocal = activity.EndTimeLocal;

        entity.StartTimeUtc = activity.StartTimeUtc;

        entity.EndTimeUtc = activity.EndTimeUtc;

        _context.Activities.Update(entity);

        return Result.Good();
    }
}
