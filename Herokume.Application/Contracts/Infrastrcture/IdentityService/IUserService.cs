using Herokume.Infrastrcture.Authentication;
using System.Security.Claims;

namespace Herokume.Application.Contracts.Infrastrcture.IdentityService;

public interface IUserService
{
    Task<ApplicationUser?> FindByIdAsync(string id);
    Task<ApplicationUser?> FindByEmailAsync(string email);
    Task<ApplicationUser?> GetByClaims(ClaimsPrincipal claims);
    Task<ApplicationUser?> GetUserWithLikedMovies(string id);
    bool IsSignIn(ClaimsPrincipal claims);
    Task<bool> IsInRoleAsync(ApplicationUser? user, string role);
    Task<bool> IsLockedOutAsync(ApplicationUser user);
    Task<IEnumerable<string>> GetRolesAsync(ApplicationUser user);
    Task<Result> ChangePasswordAsync(string userid, string oldPasswd, string newPasswd);
    Task<Result> ChangeEmailAsync(string userid, string email);
    Task<Result> ChangeUserRoleAsync(string userid, string? role);
    Task<Result> ToggleLockUserAsync(string userid);
    Task<Result> UpdateAsync(string userid, ApplicationUser user);
    Task<Result> DeleteAsync(string userid);
    Task<string> GenerateEmailConfirmationTokenAsync(string email);
    Task<string> GeneratePasswordResetTokenAsync(string userId);
    Task<Result> ResetPasswordAsync(string userEmail, string code, string newPassword);
    Task<Result> ConfirmEmailAsync(string userid, string token);
}
