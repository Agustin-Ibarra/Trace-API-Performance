using Microsoft.AspNetCore.Mvc;
using TraceApiPerformance.Api.Models;
using TraceApiPerformance.Api.Repository;
using TraceApiPerformance.Api.Hellpers;
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
    double beforeRAM = MemoryRAMHelpper.GetTotalMemoryRAM();
    try
    {
      var movies = await _movieRepository.GetMoviesList(offset);
      var afterRAM = MemoryRAMHelpper.GetTotalMemoryRAM();
      var diff = MemoryRAMHelpper.GetDifferenceMeasure(beforeRAM, afterRAM);
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
    double beforeRAM = MemoryRAMHelpper.GetTotalMemoryRAM();
    try
    {
      var movie = await _movieRepository.GetMovieDetaild(idMovie);
      double afterRAM = MemoryRAMHelpper.GetTotalMemoryRAM();
      double diff = MemoryRAMHelpper.GetDifferenceMeasure(beforeRAM, afterRAM);
      return Ok(movie);
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
      return StatusCode(503, new { errorMessage = "Ocurrio un error en la base de datos" });
    }
  }

  [HttpPost]
  public async Task<ActionResult> CreateMovie(Movie movie)
  {
    var beforeRAM = MemoryRAMHelpper.GetTotalMemoryRAM();
    try
    {
      await _movieRepository.CreateMovie(movie);
      var afterRAM = MemoryRAMHelpper.GetTotalMemoryRAM();
      var diff = MemoryRAMHelpper.GetDifferenceMeasure(beforeRAM, afterRAM);
      return Ok(movie);
    }
    catch(Exception ex)
    {
      Console.WriteLine(ex.Message);
      return StatusCode(500, new { errorMessage = "Ocurrio un error en la base de datos" });
    }
  }
}