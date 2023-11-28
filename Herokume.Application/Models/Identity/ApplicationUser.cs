using Herokume.Domain.Entities;
using Microsoft.AspNetCore.Identity;
namespace Herokume.Infrastrcture.Authentication;

public class ApplicationUser : IdentityUser
{
    public string? Avatar { get; set; }
    public string? FavoriteMovie { get; set; }
    public string? Hobby { get; set; }
    public string? RoleName { get; set; }
    public List<Series>? LikedMovies { get; set; }
}
