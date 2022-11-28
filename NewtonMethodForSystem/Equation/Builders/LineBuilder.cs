using NewtonMethodForSystem.Equation.Algebra;
using NewtonMethodForSystem.Equation.Functions;

namespace NewtonMethodForSystem.Equation.Builders;

public class LineBuilder
{
    private double _constant;
    private IVector _coefficients;

    public LineBuilder Coefficients(params double[] coefficients)
    {
        _coefficients = new Vector(coefficients);
        return this;
    }

    public LineBuilder AndConstant(double constant)
    {
        _constant = constant;
        return this;
    }

    public LineFunc Build()
    {
        if (_coefficients == null) throw new InvalidOperationException();

        return new(_constant, _coefficients);
    }
}