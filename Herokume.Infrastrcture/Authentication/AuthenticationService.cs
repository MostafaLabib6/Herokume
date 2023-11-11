using Azure.Core;
using Herokume.Application.Contracts.Infrastrcture.IdentityService;
using Herokume.Application.Contracts.Persistance;
using Herokume.Application.Models.Identity;
using Herokume.Application.Models.Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Herokume.Infrastrcture.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<ApplicationUser> _userManger;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;
    //private readonly JwtConfig _jwtConfig;

    public AuthenticationService(UserManager<ApplicationUser> userManger, IConfiguration configuration, SignInManager<ApplicationUser> signInManager)
    {
        _userManger = userManger;
        _configuration = configuration;
        _signInManager = signInManager;
        //_jwtConfig = jwtConfig;
    }
    public async Task<bool> CreateUser(ApplicationUser createduser)
    {
        var isCreated = await _userManger.CreateAsync(createduser);
        return isCreated.Succeeded;
    }
    public string GenerateToken(ApplicationUser user)
    {
        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetSection("JwtConfig:SecurityKey").Value));
        var signinCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var claimsForToken = new List<Claim>();
        claimsForToken.Add(new Claim("id", user.Id.ToString()));
        claimsForToken.Add(new Claim("sub", user.Email));
        claimsForToken.Add(new Claim("given_name", user.UserName));

        var jwtToken = new JwtSecurityToken(
            issuer: _configuration.GetSection("JwtConfig:Issuer").Value,
            audience: _configuration.GetSection("JwtConfig:Audience").Value,
            claims: claimsForToken,
            notBefore: DateTime.Now,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: signinCredentials
            );
        var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtToken);
        return tokenToReturn.ToString();
    }
    public async Task<bool> IsAuthenticated(string email)
    {
        var result = await _userManger.FindByEmailAsync(email);
        return result != null;
    }

    public async Task<AuthResult> Register(RegisterUserRequestDto user)
    {
        //check if user email is aready exist.
        var userExist = await IsAuthenticated(user.Email);
        if (userExist)
        {
            return new AuthResult()
            {
                Success = false,
                Error = new List<string>() { "email already Exist." }
            };
        }

        //create user 
        var createduser = new ApplicationUser()
        {
            UserName = user.Name,
            Email = user.Email,
        };

        var isCreated = await _userManger.CreateAsync(createduser, user.Password);
        if (!isCreated.Succeeded)
            return
                new AuthResult()
                {
                    Success = false,
                    Error = new List<string> { "Password Requiered alphanumeric,RequiredDigit and Upperletters " }
                };

        //Generate Token
        string token = GenerateToken(createduser);
        return new AuthResult() { Success = true, Token = token };
    }

    public async Task<AuthResult> Login(LoginUserRequestDto user)
    {
        //check if user email is aready exist.
        var userExist = await _userManger.FindByEmailAsync(user.Email);
        if (userExist == null)
        {
            return new AuthResult()
            {
                Success = false,
                Error = new List<string>() { "email doesn't exist." }
            };
        }

        //check the combination between email and password
        var isCorrect = await _userManger.CheckPasswordAsync(userExist, user.Password);
        //var isCorrect = await _signInManager.PasswordSignInAsync(userExist, user.Password, false, lockoutOnFailure: false);
        if (!isCorrect)
        {
            return new AuthResult()
            {
                Success = false,
                Error = new List<string>() { "Invalid Credentials" }
            };
        }

        var token = GenerateToken(userExist);
        return new AuthResult() { Success = true, Token = token };

    }

    public async Task Logout()
    {

        await _signInManager.SignOutAsync();
    }

}
