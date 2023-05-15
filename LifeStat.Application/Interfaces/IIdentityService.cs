using LifeStat.Application.UseCases.Users.Queries;
using LifeStat.Domain.Shared;

namespace LifeStat.Application.Interfaces;
public interface IIdentityService
{

    Task<Result<Guid>> CreateUserAsync(string userName, string email, string password);

    Task<Result<UserViewModel>> GetUser(Guid userId);

    Task<Result<UserViewModel>> GetUser(string email);

    Task<Result> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword);

    Task<Result> ChangeUserNameAsync(Guid userId, string newUserName);

    Task<Result> DeleteUserAsync(Guid userId);
}
