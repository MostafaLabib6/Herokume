using System.ComponentModel.DataAnnotations;

namespace Herokume.Application.Models.Identity;

public class LoginUserRequestDto
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
