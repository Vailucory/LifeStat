using LifeStat.Application.UseCases.Users.Queries;

namespace LifeStat.Application.Interfaces;
public interface IIdentityService
{

    Task<Guid?> CreateUserAsync(string userName, string email, string password);

    Task<UserViewModel?> GetUser(Guid userId);

    Task<UserViewModel?> GetUser(string email);

    Task<bool> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword);

    Task<bool> ChangeUserNameAsync(Guid userId, string newUserName);

    Task<bool> DeleteUserAsync(Guid userId);
}
