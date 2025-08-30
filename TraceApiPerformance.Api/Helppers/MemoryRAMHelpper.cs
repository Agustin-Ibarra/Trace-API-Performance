namespace TraceApiPerformance.Api.Utils;

public class MemoryRAMHelpper
{
  public static double GetTotalMemoryRAM()
  {
    return GC.GetTotalMemory(true) / 1024.0 / 1024.0; // obtiene la memoria forzando el GC
  }
  public static double GetDifferenceMeasure(double beforeRam, double afterRam)
  {
    return afterRam - beforeRam;
  }
}