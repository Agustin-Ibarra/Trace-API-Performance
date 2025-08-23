using Microsoft.EntityFrameworkCore;
using TraceApiPerformance.Api.Models;
namespace TraceApiPerformance.Api.Data;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
  public DbSet<Movie> Movies { get; set; }
  public DbSet<Classification> Classifications { get; set; }
  public DbSet<Format> Formats { get; set; }
  public DbSet<Supplier> Suppliers { get; set; }
  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Movie>().ToTable("movies");
    modelBuilder.Entity<Format>().ToTable("formats");
    modelBuilder.Entity<Supplier>().ToTable("suppliers");
  }
}