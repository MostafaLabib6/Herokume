using Herokume.Domain.Common;
using Herokume.Domain.Entities;
using Herokume.Persisitance.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Herokume.Persisitance;

public class HerokumeDbContext : DbContext
{

    public HerokumeDbContext(DbContextOptions<HerokumeDbContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);
        // modelBuilder.Entity<Category>().HasData(category1, category2);

    }
    public virtual async Task<int> SaveChangesAsync()
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
            .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
        {
            entry.Entity.ModifiedAt = DateTime.Now;
            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreatedAt = DateTime.Now;
            }
            break;
        }

        var result = await base.SaveChangesAsync();

        return result;
    }


    public DbSet<Series> Series { get; set; }
    public DbSet<Episode> Episodes { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<RelatedSeries> RelatedSeries { get; set; }
}
