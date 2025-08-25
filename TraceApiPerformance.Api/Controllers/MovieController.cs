using Microsoft.AspNetCore.Mvc;
using TraceApiPerformance.Api.Repository;
namespace TraceApiPerformance.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
  private readonly MovieRespository _movieRepository;
  public MoviesController(MovieRespository movieRespository)
  {
    _movieRepository = movieRespository;
  }
  [HttpGet("{offset}")]
  public async Task<ActionResult> GetMovies(int offset)
  {
    try
    {
      var movies = await _movieRepository.GetMoviesList(offset);
      return Ok(movies);
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
      return StatusCode(503, new { errorMessage = "Ocurrio un error en la base de datos" });
    }
  }

  [HttpGet]
  [Route("/api/movies/detail/{idMovie}")]
  public async Task<ActionResult> GetMovieInfo(int idMovie)
  {
    try
    {
      var movie = await _movieRepository.GetMovieDetaild(idMovie);
      return Ok(movie);
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
      return StatusCode(503, new { errorMessage = "Ocurrio un error en la base de datos" });
    }
  }

  // [HttpPost]
  // public ActionResult CreateMovie()
  // {
  //   return Ok();
  // }
}