using System.ComponentModel.DataAnnotations;

namespace Herokume.Application.Models.Identity;

public class RegisterUserRequestDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
