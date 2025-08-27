using Microsoft.EntityFrameworkCore;
using TraceApiPerformance.Api.Data;
using TraceApiPerformance.Api.Dtos;
using TraceApiPerformance.Api.Models;

namespace TraceApiPerformance.Api.Repository;

public class MovieRespository
{
  private readonly AppDbContext _appDbContext;
  public MovieRespository(AppDbContext appDbContext)
  {
    _appDbContext = appDbContext;
  }
  public async Task<List<MovieDto>> GetMoviesList(int offset)
  {
    return await _appDbContext.Movies
    .OrderBy(movie => movie.id_movie)
    .Select(movie => new MovieDto
    {
      Description = movie.description,
      TitleMovie = movie.title,
      IdMovie = movie.id_movie,
      Premier = movie.premier,
      Poster = movie.poster
    })
    .Skip(offset)
    .Take(15)
    .ToListAsync();
  }

  public async Task<MovieDetailDto> GetMovieDetaild(int idMovie)
  {
    return await _appDbContext.Movies
    .OrderBy(movie => movie.id_movie)
    .Include(movie => movie.ClassificationFk)
    .Include(movie => movie.FormatFk)
    .Where(movie => movie.id_movie == idMovie)
    .Select(movie => new MovieDetailDto
    {
      DescriptionMovie = movie.description,
      Poster = movie.poster,
      TitleMovie = movie.title,
      IdMovie = movie.id_movie,
      PremierMovie = movie.premier,
      Trailer = movie.trailer,
      ClassificationMovie = new ClassificationDto
      {
        TypeClassification = movie.ClassificationFk != null ? movie.ClassificationFk.type : "sin categoria"
      },
      FormatMovie = new FormatDto
      {
        TypeFormat = movie.FormatFk != null ? movie.FormatFk.type_format : "sin formato"
      }
    })
    .FirstOrDefaultAsync() ?? throw new Exception($"No se encontro la pelicula con id: {idMovie}");
  }

  public async Task CreateMovie(Movie newMovie)
  {
    _appDbContext.Movies.Add(newMovie);
    await _appDbContext.SaveChangesAsync();
  }

  public void CreateMovie() { }
}