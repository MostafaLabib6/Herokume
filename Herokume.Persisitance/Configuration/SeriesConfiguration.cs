using Herokume.Domain.Entities;
using Herokume.Persisitance.Configuration.Halper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Herokume.Persisitance.Configuration;

public class SeriesConfiguration //: IEntityTypeConfiguration<Series>
{
    public void Configure(EntityTypeBuilder<Series> builder)
    {
        builder.HasData(
                Helper.series
            );
    }
}
