using Dal.EFCore.Configurations;
using Dal.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dal.EFCore;

public class DataContext: DbContext
{
    public DbSet<Footballer> Footballers { get; set; }
    
    public DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=jhtnmb32;");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FootballerConfiguration).Assembly);
    }
}