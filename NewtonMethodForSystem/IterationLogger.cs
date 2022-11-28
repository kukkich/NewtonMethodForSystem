using NewtonMethodForSystem.Equation.Algebra;

namespace NewtonMethodForSystem;

public class IterationLogger : IDisposable
{
    private readonly StreamWriter _outStream;

    public IterationLogger(string filePath)
    {
        _outStream = new StreamWriter(filePath);
    }
    
    public void LogIteration(int iteration, Vector vector, double fkNorm, IVector direction, double betta)
    {
        Console.Write($"{iteration} {vector[0]:F15} {vector[1]:F15} {fkNorm:E3} {betta:E3}");
        Console.WriteLine();

        for (var i = 0; i < vector.Length - 1; i++)
        {
            var x = vector[i];
            _outStream.Write($"{x:F15} ");
        }
        _outStream.Write($"{vector[^1]:F15}");
        _outStream.WriteLine();
    }

    public void LogSideIteration(int i, double betta, double wNorm, double previousFuncNorm)
    {
        Console.WriteLine($"\t[{i}]:");
        Console.WriteLine($"\t\tbetta = {betta}");
        Console.WriteLine($"\t\t||F(x + step)|| = {wNorm:F15}   \t||F(x)|| = {previousFuncNorm:F15}");
    }

    public void Dispose()
    {
        _outStream.Dispose();
    }
}

public class ResearchLogger
{
    public void LogIteration(int iteration, Vector vector, double fkNorm, IVector direction, double betta)
    {
        Console.Write($"{iteration} {vector[0]:F15} {vector[1]:F15} {fkNorm:E3} {betta:E3}");
        Console.WriteLine();
    }

    public void LogSideIteration(int i, double betta, double wNorm, double previousFuncNorm)
    {
    }
}