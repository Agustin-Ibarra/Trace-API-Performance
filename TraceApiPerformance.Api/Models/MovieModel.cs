using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraceApiPerformance.Api.Models;

public class Movie
{
  [Key]
  public int id_movie { get; set; }
  public required string title { get; set; }
  public required string description { get; set; }
  public int clasification { get; set; }
  [ForeignKey("clasification")]
  public Classification? ClassificationFk { get; set; }
  public required string duration_time { get; set; }
  public required string poster { get; set; }
  public int supplier { get; set; }
  [ForeignKey("supplier")]
  public Supplier? SupplierFk { get; set; }
  public int format { get; set; }
  [ForeignKey("format")]
  public Format? FormatFk { get; set; }
  public bool premier { get; set; }
  public required string trailer { get; set; }
}