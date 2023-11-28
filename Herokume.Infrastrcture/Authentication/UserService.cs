using Herokume.Application.Contracts.Infrastrcture.EmailService;
using Herokume.Application.Contracts.Infrastrcture.IdentityService;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Models.Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Herokume.Infrastrcture.Authentication;

public class UserService : IUserService
{
    private readonly IUnitofWork _unitofWork;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IEmailService _emailService;

    public UserService(
        IUnitofWork unitOfWork,
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IUnitofWork unitofWork,
        IEmailService emailService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _unitofWork = unitofWork;
        _emailService = emailService;
    }

    public async Task<Result> ChangeEmailAsync(string userid, [EmailAddress] string email)
    {
        var user = await FindByIdAsync(userid);
        if (user == null)
            return Result.Error("Unable to load user.");

        var emailUser = await _userManager.FindByEmailAsync(email);
        if (emailUser != null)
        {
            return Result.Error($"Email {email} is already exist");
        }

        if (email != user.Email)
        {
            user.Email = email;
            user.EmailConfirmed = false;

            var result = await _userManager.UpdateAsync(user);

            return Result.ToAppResult(result);
        }

        return Result.OK();
    }

    public async Task<Result> ChangePasswordAsync(string userid, string oldPasswd, string newPasswd)
    {
        var user = await FindByIdAsync(userid);
        if (user == null)
            return Result.Error($"User {userid} Not Found");
        var result = await _userManager.ChangePasswordAsync(user, oldPasswd, newPasswd);
        return Result.ToAppResult(result);
    }

    public Task<Result> ChangeUserRoleAsync(string userid, string? role)
    {
        throw new NotImplementedException();
    }

    public async Task<Result> ConfirmEmailAsync(string userId, string token)
    {
        var user = await FindByIdAsync(userId);
        if (user == null)
            return Result.Error($"User {user?.UserName} Not Found");
        var result = await _userManager.ConfirmEmailAsync(user, token);
        return Result.ToAppResult(result);
    }

    public async Task<Result> DeleteAsync(string userid)
    {
        var user = await FindByIdAsync(userid);
        if (user == null)
            return Result.Error($"User {userid} Not Found");
        var result = await _userManager.DeleteAsync(user);

        //var userComments = _unitofWork.CommentRepository.GetCommentsWithReplies();
        //TODO:Delete user related comments 

        return Result.ToAppResult(result);
    }

    public async Task<ApplicationUser?> FindByEmailAsync(string email)
    {
        return await _userManager.FindByEmailAsync(email);
    }

    public async Task<ApplicationUser?> FindByIdAsync(string id)
    {
        return await _userManager.FindByIdAsync(id);
    }

    public async Task<string> GenerateEmailConfirmationTokenAsync([EmailAddress] string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

        var emailToSend = new Email()
        {
            Subject = "Confirm Your Email Address",
            Body = $"Hi {user.UserName},\n\n" +
               "Thank you for registering with our platform! " +
               "To complete your registration, This is the confirmation Pin" +
               $"{token}\n\n" +
               "If you did not sign up for our platform, you can ignore this email.\n\n" +
               "Best regards,\nThe Herokume Team",
            To = user.Email
        };
        await _emailService.SendEmail(emailToSend);

        return token;
    }

    public async Task<string> GeneratePasswordResetTokenAsync(string userId)
    {
        var user = await _userManager.FindByEmailAsync(userId);
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var emailToSend = new Email()
        {
            Subject = "Reset Password",
            Body = $"Dear {user.UserName},\n\n"
             + "We received a request to reset your password. Please use the following code to reset your password:\n\n"
             + $"\n\n<h3>{token}<h3>\n\n"
             + "If you did not request a password reset, please ignore this email.\n\n"
             + "Best regards,\n Herokume Team",
            To = user.Email
        };
        await _emailService.SendEmail(emailToSend);
        return token;
    }

    public async Task<ApplicationUser?> GetByClaims(ClaimsPrincipal claims)
    {
        return await _userManager.GetUserAsync(claims);
    }

    public async Task<IEnumerable<string>> GetRolesAsync(ApplicationUser user)
    {
        return await _userManager.GetRolesAsync(user);
    }

    public Task<ApplicationUser?> GetUserWithLikedMovies(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> IsInRoleAsync(ApplicationUser? user, string role)
    {
        return await _userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> IsLockedOutAsync(ApplicationUser user)
    {
        return await _userManager.IsLockedOutAsync(user);
    }

    public bool IsSignIn(ClaimsPrincipal claims)
    {
        return _signInManager.IsSignedIn(claims);
    }

    public async Task<Result> ResetPasswordAsync([EmailAddress] string userEmail, string code, string newPassword)
    {
        var user = await this.FindByEmailAsync(userEmail);
        if (user == null)
            return Result.Error($"User {userEmail} Not Found");
        var result = await _userManager.ResetPasswordAsync(user, code, newPassword);
        return Result.ToAppResult(result);
    }

    public async Task<Result> ToggleLockUserAsync(string userid)
    {
        var user = await this.FindByIdAsync(userid);

        if (user == null) return Result.Error("User not found");

        var result = await _userManager.SetLockoutEnabledAsync(user, true);

        if (!result.Succeeded) return Result.ToAppResult(result);

        if (await _userManager.IsLockedOutAsync(user))
            result = await _userManager.SetLockoutEndDateAsync(user, new DateTime(2020, 12, 20));

        else
            result = await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.Now.AddYears(10));


        return Result.ToAppResult(result);
    }

    public Task<Result> UpdateAsync(string userid, ApplicationUser user)
    {
        throw new NotImplementedException();
    }
}
