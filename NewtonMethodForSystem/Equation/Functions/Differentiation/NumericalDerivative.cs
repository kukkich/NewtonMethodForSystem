using NewtonMethodForSystem.Equation.Algebra;
using NewtonMethodForSystem.Equation.Functions.Base;

namespace NewtonMethodForSystem.Equation.Functions.Differentiation;

public class NumericalDerivative : IFunc<double, IVector>
{
    public static double Step { get; set; } = 1e-10;

    private readonly IDifferentiable _func;
    private readonly int _differentiationArgumentIndex;

    public NumericalDerivative(IDifferentiable func, int differentiationArgumentIndex)
    {
        _func = func;
        _differentiationArgumentIndex = differentiationArgumentIndex;
    }

    public double CalculateIn(IVector point)
    {
        IVector leftPoint = point.DeviateAt(_differentiationArgumentIndex, -Step);
        IVector rightPoint = point.DeviateAt(_differentiationArgumentIndex, Step);

        return (_func.CalculateIn(rightPoint) - _func.CalculateIn(leftPoint)) / (2 * Step);
    }

    public bool CanBeCalculatedIn(IVector point)
    {
        return _func.CanBeCalculatedIn(point);
    }
}