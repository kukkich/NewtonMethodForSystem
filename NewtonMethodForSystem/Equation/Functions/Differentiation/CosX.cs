using NewtonMethodForSystem.Equation.Algebra;

namespace NewtonMethodForSystem.Equation.Functions.Differentiation;

public class CosX : IFunc<double, IVector>
{
    public double Frequency { get; }
    public double Amplitude { get; }

    public CosX(double frequency, double amplitude)
    {
        Frequency = frequency;
        Amplitude = amplitude;
    }

    public double CalculateIn(IVector point)
    {
        return Amplitude * Math.Cos(Frequency * point[0]);
    }

    public bool CanBeCalculatedIn(IVector point)
    {
        return point.Length >= 1;
    }
}