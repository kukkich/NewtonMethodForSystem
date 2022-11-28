using NewtonMethodForSystem.Equation.Algebra;
using NewtonMethodForSystem.Equation.Algebra.Operations;

namespace NewtonMethodTests;

public class ColumnsRemoveTests
{
    public ColumnsRemover Remover;

    [SetUp]
    public void SetUp()
    {
        Remover = new ColumnsRemover();
    }

    [Test]
    public void RemoveFrom2X8Test()
    {
        var target = new Matrix(new double[,]
        {
                {1, 2, 3, -7, 5, 0, -2, 3},
                {2, 4, -1, 4, 8, 1, -5, 2}
        });

        var result = Remover.RemoveExcess(target);
        var expected = new Matrix(new double[,]
        {
                {-7, 5},
                {4, 8}
        });
        MatrixAssert.ComparisonPrecision = 1e-15;
        MatrixAssert.Equal(result, expected);
    }

    [Test]
    public void RemoveFromShuffled3X8Test()
    {
        var target = new Matrix(new double[,]
        {
                {1, 0,  3, 3, 5, 0,-2,-7},
                {2,-12,-1, 4, 8, 1,-5, 2},
                {1, 1,  1, 1, 1, 1, 1, 1}
        });

        var result = Remover.RemoveExcess(target);
        var expected = new Matrix(new double[,]
        {
                {0, 5, -7},
                {-12, 8, 2},
                {1, 1, 1}
        });
        MatrixAssert.ComparisonPrecision = 1e-15;
        MatrixAssert.Equal(result, expected);
    }
}
