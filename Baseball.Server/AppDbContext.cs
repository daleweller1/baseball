using Baseball.Server.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<BaseballPlayer> Players { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BaseballPlayer>()
            .Property(p => p.CaughtStealing)
            .HasDefaultValue("0"); // Default value if null
    }
}
