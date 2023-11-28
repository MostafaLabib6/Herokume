using Herokume.Application.Contracts.Infrastrcture.EmailService;
using Herokume.Application.Contracts.Infrastrcture.IdentityService;
using Herokume.Application.Models.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Herokume.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;
        public AuthenticationController
        (
            IAuthenticationService authenticationService, IEmailService emailService, IUserService userService)
        {
            _authenticationService = authenticationService;
            _emailService = emailService;
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterUserRequestDto user)
        {
            // validate user Request
            if (!ModelState.IsValid)
                return Unauthorized(new AuthResult()
                {
                    Success = false,
                    Error = new List<string>() { "UserName is Required", "Email is Required", "Password is Requierd" }
                });

            var result = await _authenticationService.Register(user);

            if (!result.Success)
                return Unauthorized(result);

            await _emailService.SendEmail(new Application.Models.Mail.Email()
            {
                Subject = "Email Created successfully",
                Body = $"\"Dear Anime Fan,\\n\\n\" +\r\n Email Created Successfully",
                To = user.Email
            });

            return Ok(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUserRequestDto user)
        {
            if (!ModelState.IsValid)
                return Unauthorized(new AuthResult()
                {
                    Success = false,
                    Error = new List<string>() { "Email is Required", "Password is Requierd" }
                });
            var result = await _authenticationService.Login(user);

            if (!result.Success)
                return Unauthorized(result);

            return Ok(result);
        }

        [HttpPost("Logout")]
        //[Authorize]
        public async Task<IActionResult> Logout()
        {
            await _authenticationService.Logout();
            return Ok();
        }

        [HttpPost("/changeEmail/{userId}/")]
        public async Task<Result> ChangeEmail([FromRoute] string userId, [FromBody] string email)
        {
            return await _userService.ChangeEmailAsync(userId, email);
        }

        [HttpPost("/changePassword/{userId}")]
        public async Task<Result> ChangePassword(
            [FromRoute] string userId,
            string oldPassword,
            string newPassword)
        {
            return await _userService.ChangePasswordAsync(userId, oldPassword, newPassword);
        }

        [HttpPost("/generateConfimrationToken/{email}")]
        public async Task<string> GenerateConfirmationToken(string email)
        {
            return await _userService.GenerateEmailConfirmationTokenAsync(email);
        }

        [HttpPost("/ConfirmEmail/{userId}")]
        public async Task<Result> ConfirmEmail(string userId, string token)
        {
            return await _userService.ConfirmEmailAsync(userId, token);
        }

        [HttpPost("/resetPasswordToken/{userId}")]
        public async Task<string> GenerateResetPasswordCode(string userId)
        {
            return await _userService.GeneratePasswordResetTokenAsync(userId);
        }

        [HttpPost("/resetPassword/")]
        public async Task<Result> ResetPassword(ResetPassword resetPassword)
        {
            return await _userService.ResetPasswordAsync(resetPassword.Email, resetPassword.Code, resetPassword.NewPassword);
        }
    }

    public class ResetPassword
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string Code { get; set; }
    }
}
