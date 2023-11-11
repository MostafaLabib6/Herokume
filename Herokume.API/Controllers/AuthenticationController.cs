using Herokume.Application.Contracts.Infrastrcture.IdentityService;
using Herokume.Application.Models.Identity;
using Herokume.Infrastrcture.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Herokume.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController
        (
            IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
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
    }
}
