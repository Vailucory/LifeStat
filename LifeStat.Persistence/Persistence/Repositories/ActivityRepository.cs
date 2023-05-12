using AutoMapper;
using Domain.Models;
using LifeStat.Domain.Exceptions;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Infrastructure.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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

    public void Add(Activity activity, int userId)
    {
        (_context.InnerUsers
            .FirstOrDefault(u => u.Id == userId)
            ?.Activities
            ?? throw new EntityNotFoundException(userId, typeof(User)))
            .Add(_mapper.Map<ActivityDL>(activity));
    }

    public async Task<Activity> GetByIdAsync(int id)
    {
        return _mapper.Map<Activity>(await _context.Activities
            .FindAsync(id))
            ?? throw new EntityNotFoundException(id, typeof(Activity));
    }

    public async Task<List<Activity>> GetAllUserActivitiesAsync(int userId)
    {
        return _mapper.Map<List<Activity>>(await _context.Activities
            .Where(a => a.UserId == userId)
            .ToListAsync());
    }

    public async Task<List<Activity>> GetAllUserActivitiesFromTimeAsync(int userId, DateTime fromTime)
    {
        var activities = _mapper.Map<List<Activity>>(await _context
            .Activities
            .Where(a => a.UserId == userId && a.StartTimeLocal >= fromTime)
            .ToListAsync());

        return activities;
    }

    public async Task<List<Activity>> GetActivitiesByTemplateIdAsync(int templateId)
    {
        return _mapper.Map<List<Activity>>(await _context
            .Activities
            .Where(a => a.ActivityTemplateId == templateId)
            .ToListAsync());
    }

    public void Remove(Activity activity)
    {
        _context.Activities.Remove(_mapper.Map<ActivityDL>(activity));
    }

    public void Update(Activity activity)
    {
        _context.Activities.Update(_mapper.Map<ActivityDL>(activity));
    }
}
