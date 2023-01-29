using Microsoft.EntityFrameworkCore;
using TestCase.Domain.Entities;
using TestCase.Repository.Mapper;

namespace TestCase.Repository;

public class TestCaseDbContext: DbContext
{
    public TestCaseDbContext(DbContextOptions options) : base(options)
    {
    
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new OrderMapper().BaseMap(modelBuilder);

        base.OnModelCreating(modelBuilder);
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        this.ChangeTracker.DetectChanges();
        var added = this.ChangeTracker.Entries()
            .Where(t => t.State == EntityState.Added)
            .Select(t => t.Entity)
            .ToArray();

        foreach (var entity in added)
        {
            if (entity is Entity track)
            {
                track.CreatedDate = DateTime.Now;
                track.IsActive = true;
            }
        }

        var modified = this.ChangeTracker.Entries()
            .Where(t => t.State == EntityState.Modified)
            .Select(t => t.Entity)
            .ToArray();

        foreach (var entity in modified)
        {
            if (entity is Entity track)
            {
                track.ModifiedDate = DateTime.Now;
            }
        }
        return base.SaveChangesAsync();
    }
}