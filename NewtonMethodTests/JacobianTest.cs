using NewtonMethodForSystem.Equation;
using NewtonMethodForSystem.Equation.Algebra;
using NewtonMethodForSystem.Equation.Functions;
using NewtonMethodForSystem.Equation.Functions.Differentiation;

namespace NewtonMethodTests;

public class JacobianTest
{
    public FunctionalVector FunctionVector { get; set; }

    [SetUp]
    public void Setup()
    {
        FunctionVector = new FunctionalVector(
            new CircleFunc(2, new Vector(2d, 0d)),
            new CircleFunc(4, new Vector(-3d, 1d))
        );

        NumericalDerivative.Step = 1e-9;
    }

    [Test]
    public void Test1()
    {
        var point = new Vector(7, -1);
        var jacobian = FunctionVector.Jacobian(point, new NumericalDifferentiationOperator());

        var expected = new Matrix(
            new double[,]
            {
                {2 * (point[0] - 2), 2 * point[1]},
                {2 * (point[0] + 3), 2 * (point[1] - 1)},
            }
        );

        MatrixAssert.ComparisonPrecision = 1e-1;
        MatrixAssert.Equal(jacobian, expected);
    }
}