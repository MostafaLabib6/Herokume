using Herokume.Domain.Common;

namespace Herokume.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public List<Series>? Series { get; set; }

}
