using System.ComponentModel.DataAnnotations;

namespace TraceApiPerformance.Api.Models;

public class Classification
{
  [Key]
  public int id_clasification { get; set; }
  public required string type { get; set; }
  public bool enabled { get; set; }
  public ICollection<Movie>? MovieReferences { get; set; }
}