using System.ComponentModel.DataAnnotations;

namespace TraceApiPerformance.Api.Models;

public class Format
{
  [Key]
  public int id_format { get; set; }
  public required string type_format { get; set; }
  public bool enabled { get; set; }
  public ICollection<Movie>? MovieReferences { get; set; }
}