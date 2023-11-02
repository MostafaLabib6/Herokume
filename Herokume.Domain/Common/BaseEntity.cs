namespace Herokume.Domain.Common;

public class BaseEntity
{
    public Guid ID { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? ModifiedAt { get; set; }

}
