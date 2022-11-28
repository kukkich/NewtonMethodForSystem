using NewtonMethodForSystem.Equation.Algebra;
using NewtonMethodForSystem.Equation.Functions.Base;
using NewtonMethodForSystem.Equation.Functions.Differentiation;

namespace NewtonMethodForSystem.Equation.Functions;

public class LineFunc : IDifferentiable
{
    public double Constant { get; }
    public IVector Coefficients { get; }

    public LineFunc(double constant, IVector coefficients)
    {
        Coefficients = coefficients;
        Constant = constant;
    }

    public double CalculateIn(IVector point)
    {
        if (!CanBeCalculatedIn(point))
            throw new ArgumentOutOfRangeException($"{nameof(point)} must have {Coefficients.Length} dimensions");

        var sum = point
            .Select((x, i) => x * Coefficients[i])
            .Sum();

        return sum - Constant;
    }

    public bool CanBeCalculatedIn(IVector point) => point.Length == Coefficients.Length;
    public IFunc<double, IVector> DerivativeBy(IDifferentiationOperator @operator, int differentiationArgumentIndex)
    {
        return @operator.DifferentiateLine(this, differentiationArgumentIndex);
    }
}