using System.ComponentModel.DataAnnotations;

namespace TraceApiPerformance.Api;

public class Supplier
{
  [Key]
  public int id_supplier { get; set; }
  public required string supplier { get; set; }
  public bool active { get; set; }
  public ICollection<Movie>? MovieReferences { get; set; }
}