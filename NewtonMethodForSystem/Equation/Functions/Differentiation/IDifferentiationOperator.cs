using NewtonMethodForSystem.Equation.Algebra;

namespace NewtonMethodForSystem.Equation.Functions.Differentiation
{
    public interface IDifferentiationOperator
    {
        public IFunc<double, IVector> DifferentiateCircle(CircleFunc target, int differentiationArgumentIndex);
        public IFunc<double, IVector> DifferentiateLine(LineFunc target, int differentiationArgumentIndex);
        public IFunc<double, IVector> DifferentiateConstant(ConstantFunc target);
        public IFunc<double, IVector> DifferentiateSinX(SinX target);
    }
}
