using Herokume.Application.Models.Identity;
using Herokume.Infrastrcture.Authentication;

namespace Herokume.Application.Contracts.Infrastrcture.IdentityService;

public interface IAuthenticationService
{
    public Task<bool> IsAuthenticated(string email);
    public string GenerateToken(ApplicationUser user);
    public Task Logout();
    public Task<bool> CreateUser(ApplicationUser user);
    Task<AuthResult> Login(LoginUserRequestDto user);
    Task<AuthResult> Register(RegisterUserRequestDto user);
}
