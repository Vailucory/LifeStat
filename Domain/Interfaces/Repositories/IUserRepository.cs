using Domain.Models;

namespace LifeStat.Domain.Interfaces.Repositories;
public interface IUserRepository
{
    void Add(User user);

    Task<User> GetByIdAsync(int id);

    Task<User> GetByIdWithTemplatesAsync(int id);

    Task<User> GetByIdWithPlansAsync(int id);

    Task<User> GetByIdWithActivitiesAsync(int id);

    void Update(User user);

    void Remove(User user);
}
