using NewtonMethodForSystem.Equation.Algebra;
using NewtonMethodForSystem.Equation.Functions.Base;
using NewtonMethodForSystem.Equation.Functions.Differentiation;

namespace NewtonMethodForSystem.Equation.Functions;

public class ConstantFunc : IDifferentiable
{
    public double Constant { get; }

    public ConstantFunc(double constant)
    {
        Constant = constant;
    }

    public double CalculateIn(IVector point) => Constant;

    public bool CanBeCalculatedIn(IVector point) => true;

    public IFunc<double, IVector> DerivativeBy(IDifferentiationOperator @operator, int differentiationArgumentIndex)
    {
        return @operator.DifferentiateConstant(this);
    }
}