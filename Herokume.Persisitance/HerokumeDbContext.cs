using Herokume.Application.Dtos.Series;
using Herokume.Domain.Common;
using Herokume.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Herokume.Persisitance;

public class HerokumeDbContext : DbContext
{
    public HerokumeDbContext(DbContextOptions<HerokumeDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        foreach (var entity in ChangeTracker.Entries<BaseEntity>())
        {
            entity.Entity.ModifiedAt = DateTime.Now;
            if (entity.State == EntityState.Added)
                entity.Entity.CreatedAt = DateTime.Now;
        }
        return base.SaveChangesAsync(cancellationToken);

    }


    public DbSet<Series> Series { get; set; }
    public DbSet<Episode> Episodes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<CommentResponse> CommentResponses { get; set; }
    public DbSet<RelatedSeries> RelatedSeries { get; set; }
}
