using Microsoft.EntityFrameworkCore;
namespace TraceApiPerformance.Api;

public class AppDbContext : DbContext
{
  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
  
}