namespace TraceApiPerformance.Api.Hellpers;

public class CpuHelper
{
  public static double GetUsedCpu(TimeSpan beforeCpu, TimeSpan afterCpu)
  {
    return (afterCpu - beforeCpu).TotalMilliseconds; // obtiene el timepo de CPU usado
  }

  public static double GetPercentCpu(double usedCpu,double timeTranscurred) {
    int cores = Environment.ProcessorCount;
    return (usedCpu / (timeTranscurred * cores)) * 100;
  }
}