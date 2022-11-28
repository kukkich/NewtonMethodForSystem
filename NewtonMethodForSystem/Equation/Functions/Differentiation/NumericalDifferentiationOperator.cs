using NewtonMethodForSystem.Equation.Algebra;

namespace NewtonMethodForSystem.Equation.Functions.Differentiation;

public class NumericalDifferentiationOperator : IDifferentiationOperator
{
    public IFunc<double, IVector> DifferentiateCircle(CircleFunc target, int differentiationArgumentIndex) =>
        new NumericalDerivative(target, differentiationArgumentIndex);

    public IFunc<double, IVector> DifferentiateLine(LineFunc target, int differentiationArgumentIndex) =>
        new NumericalDerivative(target, differentiationArgumentIndex);

    public IFunc<double, IVector> DifferentiateConstant(ConstantFunc target)
    {
        return new ConstantFunc(0);
    }

    public IFunc<double, IVector> DifferentiateSinX(SinX target)
    {
        return new NumericalDerivative(target, 0);
    }
}