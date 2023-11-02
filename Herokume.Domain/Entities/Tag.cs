using Herokume.Domain.Common;

namespace Herokume.Domain.Entities;

public class Tag:BaseEntity
{
    public string TagName { get; set; } =string.Empty;
    public Series? Series { get; set; }
}
