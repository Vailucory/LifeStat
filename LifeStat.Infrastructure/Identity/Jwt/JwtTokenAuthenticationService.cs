using LifeStat.Application.Interfaces;
using LifeStat.Domain.Shared;
using LifeStat.Domain.Shared.Errors;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace LifeStat.Infrastructure.Identity.Jwt;
internal class JwtTokenAuthenticationService : IJwtTokenAuthenticationService
{
    private static readonly Error error = new Error("Email or Password",
        "Invalid email or password. Please check your credentials and try again.");

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

    public async Task<Result<string>> Authenticate(string email, string password)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
            return Result<string>.FromError(error);

        var signinResult = await _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure: false);


        if (!signinResult.Succeeded)
            return Result<string>.FromError(error);

        string token = new JwtTokenGenerator(_jwtConfigurationSettings).Generate(user);

        return Result<string>.Good(token);

    }
}
