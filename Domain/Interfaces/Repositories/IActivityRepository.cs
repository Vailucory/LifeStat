using Domain.Models;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IActivityRepository
{
    void Add(Activity activity);

    Task<Activity> GetByIdAsync(int id);

    void Update(Activity activity);

    void Remove(Activity activity);
}
