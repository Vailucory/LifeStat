using LifeStat.Application.Interfaces;
using LifeStat.Application.UseCases.Users.Queries;
using Microsoft.AspNetCore.Identity;

namespace LifeStat.Infrastructure.Identity;
public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public IdentityService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user == null)
            return false;
        
        var result = await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);

        return result.Succeeded;
    }

    public async Task<bool> ChangeUserNameAsync(Guid userId, string newUserName)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user == null)
            return false;

        var changeUserNameResult = await _userManager.SetUserNameAsync(user, newUserName);

        return changeUserNameResult.Succeeded;
    }

    public async Task<Guid?> CreateUserAsync(string userName, string email, string password)
    {
        var userToCreate = new ApplicationUser()
        {
            UserName = userName,
            Email = email
        };

        var creationResult = await _userManager.CreateAsync(userToCreate, password);

        if (creationResult.Succeeded)
        {
            var createdUser = await _userManager.FindByEmailAsync(email);
            return createdUser?.Id;
        }

        return null;
    }

    public async Task<bool> DeleteUserAsync(Guid userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user is null)
        {
            return false;
        }

        var deletionResult = await _userManager.DeleteAsync(user);

        return deletionResult.Succeeded;
    }

    public async Task<UserViewModel?> GetUser(Guid userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());

        if (user is null)
            return null;

        return new UserViewModel(user.Id, user.UserName!, user.Email!);
    }

    public async Task<UserViewModel?> GetUser(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user is null)
            return null;

        return new UserViewModel(user.Id, user.UserName!, user.Email!);
    }
}
