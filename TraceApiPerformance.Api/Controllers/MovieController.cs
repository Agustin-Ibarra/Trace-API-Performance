using Microsoft.AspNetCore.Mvc;
namespace TraceApiPerformance.Api;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
  [HttpGet]
  public ActionResult GetMovies()
  {
    return Ok();
  }

  [HttpGet("{idMovie}")]
  public ActionResult GetMovieInfo(int idMovie)
  {
    return Ok();
  }

  [HttpPost]
  public ActionResult CreateMovie()
  {
    return Ok();
  }
}