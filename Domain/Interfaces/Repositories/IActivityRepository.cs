using Domain.Models;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IActivityRepository
{
    Task AddAsync(Activity activity);

    Task<Activity> GetByIdAsync(int id);

    Task UpdateAsync(Activity activity);

    Task RemoveAsync(Activity activity);
}
