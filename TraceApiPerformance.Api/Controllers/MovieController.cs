using Microsoft.AspNetCore.Mvc;
using TraceApiPerformance.Api.Repository;
namespace TraceApiPerformance.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
  private readonly MovieRespository _movieRepository;
  public MovieController(MovieRespository movieRespository)
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

  // [HttpGet("/detail/{idMovie}")]
  // public ActionResult GetMovieInfo(int idMovie)
  // {
  //   return Ok();
  // }

  // [HttpPost]
  // public ActionResult CreateMovie()
  // {
  //   return Ok();
  // }
}