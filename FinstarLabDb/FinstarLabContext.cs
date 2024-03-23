using FinstarLab.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinStarLab.Db;

public class FinstarLabContext : DbContext
{
    public DbSet<CodeValue> CodeValues { get; set; }

    public FinstarLabContext()
    {
        Database.EnsureCreated();
    }

    public FinstarLabContext(DbContextOptions<FinstarLabContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=FinstarLab.Db-Dev;User Id=postgres;Password=postgres;");
    }
}