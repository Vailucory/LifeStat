using LifeStat.Domain.Shared;
using LifeStat.Domain.Shared.Errors;
using LifeStat.Infrastructure.Common;
using Microsoft.AspNetCore.Identity;

namespace LifeStat.Infrastructure.Identity;
public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public IdentityService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<Result> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user is null)
            return Result.FromError(new UserNotFoundError(userId));

        var changePasswordIdentityResult = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

        return Result.FromErrors(changePasswordIdentityResult.ExtractErrors());
    }

    public async Task<Result> ChangeUserNameAsync(Guid userId, string newUserName)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user is null)
            return Result.FromError(new UserNotFoundError(userId));

        var changeUserNameIdentityResult = await _userManager.SetUserNameAsync(user, newUserName);

        return Result.FromErrors(changeUserNameIdentityResult.ExtractErrors());
    }

    public async Task<Result<Guid>> CreateUserAsync(string userName, string email, string password)
    {
        var userToCreate = new ApplicationUser()
        {
            UserName = userName,
            Email = email
        };

        var creationIdentityResult = await _userManager.CreateAsync(userToCreate, password);

        if (creationIdentityResult.Succeeded)
        {
            var createdUser = await _userManager.FindByEmailAsync(email);
            return Result<Guid>.Good(createdUser!.Id);
        }

        return Result<Guid>.FromErrors(creationIdentityResult.ExtractErrors());
    }

    public async Task<Result> DeleteUserAsync(Guid userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user is null)
            return Result.FromError(new UserNotFoundError(userId));

        var deletionIdentityResult = await _userManager.DeleteAsync(user);

        return Result.FromErrors(deletionIdentityResult.ExtractErrors());
    }

    public async Task<Result<UserViewModel>> GetUser(Guid userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user is null)
            return Result<UserViewModel>.FromError(new UserNotFoundError(userId));

        return Result<UserViewModel>.Good(new UserViewModel(user.Id, user.UserName!, user.Email!));
    }

    public async Task<Result<UserViewModel>> GetUser(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
            return Result<UserViewModel>.
                FromError(new UserNotFoundError(email, "email"));

        return Result<UserViewModel>.Good(new UserViewModel(user.Id, user.UserName!, user.Email!));
    }
}
