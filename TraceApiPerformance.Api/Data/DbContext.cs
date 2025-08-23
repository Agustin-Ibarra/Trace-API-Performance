using Microsoft.EntityFrameworkCore;
namespace TraceApiPerformance.Api;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
  public DbSet<Movie> Movies { get; set; }
  public DbSet<Classification> Classifications { get; set; }
  public DbSet<Format> Formats { get; set; }
  public DbSet<Supplier> Suppliers { get; set; }
}