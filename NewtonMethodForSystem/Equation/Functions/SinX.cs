using NewtonMethodForSystem.Equation.Algebra;
using NewtonMethodForSystem.Equation.Functions.Base;
using NewtonMethodForSystem.Equation.Functions.Differentiation;

namespace NewtonMethodForSystem.Equation.Functions;

public class SinX : IDifferentiable
{
    public double Frequency { get; }
    public double Amplitude { get; }

    public SinX(double frequency, double amplitude)
    {
        Frequency = frequency;
        Amplitude = amplitude;
    }

    public double CalculateIn(IVector point)
    {
        return Amplitude * Math.Sin(Frequency * point[0]);
    }

    public bool CanBeCalculatedIn(IVector point)
    {
        return point.Length >= 1;
    }

    public IFunc<double, IVector> DerivativeBy(IDifferentiationOperator @operator, int differentiationArgumentIndex)
    {
        return @operator.DifferentiateSinX(this);
    }
}
