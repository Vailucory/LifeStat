using LifeStat.Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace LifeStat.Infrastructure.Identity.Jwt;
internal class JwtTokenAuthenticationService : IJwtTokenAuthenticationService
{
    //Secret
    private readonly JwtConfigurationSettings _jwtConfigurationSettings;

    private readonly SignInManager<ApplicationUser> _signInManager;

    private readonly UserManager<ApplicationUser> _userManager;

    public JwtTokenAuthenticationService(
        IOptions<JwtConfigurationSettings> jwtConfigurationSettings,
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager)
    {
        _jwtConfigurationSettings = jwtConfigurationSettings.Value!;
        _signInManager = signInManager;
        _userManager = userManager;
    }

    public async Task<string?> Authenticate(string Email, string Password)
    {
        var user = await _userManager.FindByEmailAsync(Email);

        if (user == null)
            return null;

        var signinResult = await _signInManager.CheckPasswordSignInAsync(user, Password, lockoutOnFailure: false);

        if (!signinResult.Succeeded)
            return null;

        string token = new JwtTokenGenerator(_jwtConfigurationSettings).Generate(user);

        return token;

    }
}
