using Herokume.Domain.Entities;
using Herokume.Persisitance.Configuration.Halper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Herokume.Persisitance.Configuration;

public class EpisodeConfiguration //: IEntityTypeConfiguration<Episode>
{
    public void Configure(EntityTypeBuilder<Episode> builder)
    {
        builder.HasData(
            Helper.episode1,
            Helper.episode2
            );
    }
}
