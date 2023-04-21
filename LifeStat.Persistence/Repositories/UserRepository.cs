using AutoMapper;
using Domain.Models;
using LifeStat.Domain.Exceptions;
using LifeStat.Domain.Interfaces.Repositories;
using LifeStat.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace LifeStat.Persistence.Repositories;
public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    private readonly IMapper _mapper;

    public UserRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public void Add(User user)
    {
        _context.Users.Add(_mapper.Map<UserDL>(user));
    }

    public async Task<User> GetByIdAsync(int id)
    {
        return _mapper.Map<User>(await _context.Users
            .FindAsync(id)
            ?? throw new EntityNotFoundException(id, typeof(User)));
    }

    public async Task<User> GetByIdWithActivitiesAsync(int id)
    {
        return _mapper.Map<User>(await _context
            .Users
            .Include(u => u.Activities)
            .FirstOrDefaultAsync(u => u.Id == id)
            ?? throw new EntityNotFoundException(id, typeof(User)));
    }

    public async Task<User> GetByIdWithPlansAsync(int id)
    {
        return _mapper.Map<User>(await _context
            .Users
            .Include(u => u.DailyPlans)
            .Include(u => u.WeeklyPlans)
            .FirstOrDefaultAsync(u => u.Id == id)
            ?? throw new EntityNotFoundException(id, typeof(User)));
    }

    public async Task<User> GetByIdWithTemplatesAsync(int id)
    {
        return _mapper.Map<User>(await _context
            .Users
            .Include(u => u.ActivityTemplates)
            .Include(u => u.DailyPlanTemplates)
            .Include(u => u.WeeklyPlanTemplates)
            .FirstOrDefaultAsync(u => u.Id == id)
            ?? throw new EntityNotFoundException(id, typeof(User)));
    }

    public void Remove(User user)
    {
        _context.Users.Remove(_mapper.Map<UserDL>(user));
    }

    public void Update(User user)
    {
        _context.Users.Update(_mapper.Map<UserDL>(user));
    }
}
