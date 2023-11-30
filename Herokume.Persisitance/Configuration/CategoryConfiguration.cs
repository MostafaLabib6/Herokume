using Herokume.Domain.Entities;
using Herokume.Persisitance.Configuration.Halper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Herokume.Persisitance.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasData(
            Helper.category1,
            Helper.category2
            );
    }
}
