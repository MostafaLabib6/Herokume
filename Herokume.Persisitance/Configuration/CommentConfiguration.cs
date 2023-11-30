using Herokume.Domain.Entities;
using Herokume.Persisitance.Configuration.Halper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Herokume.Persisitance.Configuration;

public class CommentConfiguration //: IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.HasData(
            Helper.SeriesComment,
            Helper.EpisodeComment);
    }
}
