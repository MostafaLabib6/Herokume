namespace Herokume.Domain.Entities;

public class Tag
{
    public string TagName { get; set; } =string.Empty;
    public Series? Series { get; set; }
}
