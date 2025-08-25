using TraceApiPerformance.Api.Models;

namespace TraceApiPerformance.Api.Dtos;

public class MovieDto
{
  public int IdMovie { get; set; }
  public required string TitleMovie { get; set; }
  public required string Description { get; set; }
  public bool Premier { get; set; }
  public required string Poster { get; set; }
}

public class MovieDetailDto
{
  public int IdMovie { get; set; }
  public required string TitleMovie { get; set; }
  public required string DescriptionMovie { get; set; }
  public bool PremierMovie { get; set; }
  public required string Poster { get; set; }
  public ClassificationDto? ClassificationMovie { get; set; }
  public FormatDto? FormatMovie { get; set; }
  public required string Trailer { get; set; }
}