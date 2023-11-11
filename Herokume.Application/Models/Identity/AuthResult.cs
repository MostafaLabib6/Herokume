namespace Herokume.Application.Models.Identity;

public class AuthResult
{
    public bool Success { get; set; }
    public List<string> Error { get; set; } = new List<string>();
    public string Token { get; set; } = string.Empty;

}
