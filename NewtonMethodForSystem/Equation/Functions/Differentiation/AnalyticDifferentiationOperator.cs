using NewtonMethodForSystem.Equation.Algebra;
using NewtonMethodForSystem.Equation.Builders;

namespace NewtonMethodForSystem.Equation.Functions.Differentiation;

    public class AnalyticDifferentiationOperator : IDifferentiationOperator
    {
        public IFunc<double, IVector> DifferentiateCircle(CircleFunc target, int differentiationArgumentIndex)
        {
            var lineCoefficients = new double[target.Center.Length];
            lineCoefficients[differentiationArgumentIndex] = 1;
            var lineConstant = target.Center[differentiationArgumentIndex];

            return new LineBuilder()
                .Coefficients(lineCoefficients)
                .AndConstant(lineConstant)
                .Build();
        }

        public IFunc<double, IVector> DifferentiateLine(LineFunc target, int differentiationArgumentIndex)
        {
            var constant = target.Coefficients[differentiationArgumentIndex];
            return new ConstantFunc(constant);
        }

        public IFunc<double, IVector> DifferentiateConstant(ConstantFunc target)
        {
            return new ConstantFunc(0);
        }

        public IFunc<double, IVector> DifferentiateSinX(SinX target)
        {
            return new CosX(target.Frequency, target.Amplitude * target.Frequency);
        }
    }