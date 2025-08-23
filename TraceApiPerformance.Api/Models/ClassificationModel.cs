using System.ComponentModel.DataAnnotations;

namespace TraceApiPerformance.Api;

public class Classification
{
  [Key]
  public int id_classification { get; set; }
  public required string type { get; set; }
  public bool enabled { get; set; }
  public ICollection<Movie>? MovieReferences { get; set; }
}