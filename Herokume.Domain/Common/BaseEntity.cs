namespace Herokume.Domain.Common;

public class BaseEntity
{
    public Guid ID { get; set; } = Guid.NewGuid();
    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public DateTime? ModifiedAt { get; set; } = DateTime.Now;

}
