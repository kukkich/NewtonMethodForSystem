using NewtonMethodForSystem.Equation.Algebra;
using NewtonMethodForSystem.Equation.Functions.Differentiation;

namespace NewtonMethodForSystem.Equation.Functions.Base;

public interface IDifferentiable : IFunc<double, IVector>
{
    public IFunc<double, IVector> DerivativeBy(IDifferentiationOperator @operator, int differentiationArgumentIndex);
}