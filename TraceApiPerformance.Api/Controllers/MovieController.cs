using Microsoft.AspNetCore.Mvc;
using TraceApiPerformance.Api.Models;
using TraceApiPerformance.Api.Repository;
using TraceApiPerformance.Api.Hellpers;
using System.Diagnostics;
namespace TraceApiPerformance.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController : ControllerBase
{
  private readonly MovieRespository _movieRepository;
  private readonly ILogger<MoviesController> _logger;
  public MoviesController(MovieRespository movieRespository, ILogger<MoviesController> logger)
  {
    _movieRepository = movieRespository;
    _logger = logger;
  }
  [HttpGet("{offset}")]
  public async Task<ActionResult> GetMovies(int offset)
  {
    double beforeRAM = MemoryRAMHelpper.GetTotalMemoryRAM();
    var process = Process.GetCurrentProcess();
    var beforeCPU = process.TotalProcessorTime;
    var stopWatch = Stopwatch.StartNew();
    try
    {
      var movies = await _movieRepository.GetMoviesList(offset);
      var afterRAM = MemoryRAMHelpper.GetTotalMemoryRAM();
      var diff = MemoryRAMHelpper.GetDifferenceMeasure(beforeRAM, afterRAM);
      var afterCPU = process.TotalProcessorTime;
      stopWatch.Stop();
      double usedCpu = CpuHelper.GetUsedCpu(beforeCPU, afterCPU);
      double timeTranscurred = stopWatch.Elapsed.TotalMilliseconds;
      double percentCpu = CpuHelper.GetPercentCpu(usedCpu, timeTranscurred);
      _logger.LogInformation("Path: /api/movies Method: GET Status 200 CPU percent {percentCpu:F2}% RAM: {diff:F2}MB", percentCpu, diff);
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
    var process = Process.GetCurrentProcess();
    var beforeCPU = process.TotalProcessorTime;
    var stopWatch = Stopwatch.StartNew();
    double beforeRAM = MemoryRAMHelpper.GetTotalMemoryRAM();
    try
    {
      var movie = await _movieRepository.GetMovieDetaild(idMovie);
      double afterRAM = MemoryRAMHelpper.GetTotalMemoryRAM();
      double diff = MemoryRAMHelpper.GetDifferenceMeasure(beforeRAM, afterRAM);
      var afterCPU = process.TotalProcessorTime;
      stopWatch.Stop();
      double usedCpu = CpuHelper.GetUsedCpu(beforeCPU, afterCPU);
      double timeTranscurred = stopWatch.Elapsed.TotalMilliseconds;
      double percentCpu = CpuHelper.GetPercentCpu(usedCpu, timeTranscurred);
      _logger.LogInformation("Path: /api/movies/detail/{id} Method: GET Status 200 CPU percent {percentCpu:F2}% RAM: {diff:F2}MB",idMovie , percentCpu, diff);
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
    var process = Process.GetCurrentProcess();
    var beforeCPU = process.TotalProcessorTime;
    var stopWatch = Stopwatch.StartNew();
    var beforeRAM = MemoryRAMHelpper.GetTotalMemoryRAM();
    try
    {
      await _movieRepository.CreateMovie(movie);
      var afterRAM = MemoryRAMHelpper.GetTotalMemoryRAM();
      var diff = MemoryRAMHelpper.GetDifferenceMeasure(beforeRAM, afterRAM);
      var afterCPU = process.TotalProcessorTime;
      stopWatch.Stop();
      double usedCpu = CpuHelper.GetUsedCpu(beforeCPU, afterCPU);
      double timeTranscurred = stopWatch.Elapsed.TotalMilliseconds;
      double percentCpu = CpuHelper.GetPercentCpu(usedCpu, timeTranscurred);
      _logger.LogInformation("Path: /api/movies Method: POST Status 200 CPU percent {percentCpu:F2}% RAM: {diff:F2}MB", percentCpu, diff);
      return Ok(movie);
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
      return StatusCode(500, new { errorMessage = "Ocurrio un error en la base de datos" });
    }
  }
}