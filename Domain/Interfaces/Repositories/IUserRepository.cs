using Domain.Models;

namespace LifeStat.Domain.Interfaces.Repositories;
internal interface IUserRepository
{
    Task AddAsync(User user);

    Task<User> GetByIdAsync(int id);

    Task<User> GetByIdWithTemplatesAsync(int id);

    Task<User> GetByIdWithCurrentChoicesAsync(int id);

    Task<User> GetByIdWithPlansAsync(int id);

    Task<User> GetByIdWithActivitiesAsync(int id);

    Task UpdateAsync(User user);

    Task RemoveAsync(User user);
}
