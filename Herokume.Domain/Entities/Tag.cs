using Herokume.Domain.Common;

namespace Herokume.Domain.Entities;

public class Tag : BaseEntity
{
    public string TagName { get; set; } = string.Empty;
    public ICollection<Series>? Series { get; set; } = new List<Series>();
}
