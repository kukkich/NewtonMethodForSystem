using NewtonMethodForSystem.Equation.Algebra;
using NewtonMethodForSystem.Equation.Functions.Base;
using NewtonMethodForSystem.Equation.Functions.Differentiation;

namespace NewtonMethodForSystem.Equation.Functions;

public class CircleFunc : IDifferentiable
{
    public double Radius { get; }
    public IVector Center { get; }

    public CircleFunc(double radius, IVector center)
    {
        Radius = radius;
        Center = center;
    }

    public double CalculateIn(IVector point)
    {
        if (!CanBeCalculatedIn(point))
            throw new ArgumentOutOfRangeException($"{nameof(point)} must have {Center.Length} dimensions");

        var sum = point
            .Select((x, i) => Math.Pow(x - Center[i], 2))
            .Sum();

        return sum - Math.Pow(Radius, 2);
    }

    public bool CanBeCalculatedIn(IVector point) => point.Length == Center.Length;

    public IFunc<double, IVector> DerivativeBy(IDifferentiationOperator @operator, int differentiationArgumentIndex)
    {
        return @operator.DifferentiateCircle(this, differentiationArgumentIndex);
    }
}