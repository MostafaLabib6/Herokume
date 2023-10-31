namespace Herokume.Application.Dtos.Comment
{
    public class BaseComment:BaseDto
    {
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}