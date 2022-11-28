using NewtonMethodForSystem.Equation.Algebra;

namespace NewtonMethodTests;

internal class MatrixAssert
{
    public static double ComparisonPrecision = 1e-3;

    public static void Equal(Matrix a, Matrix b)
    {
        Assert.Multiple(() =>
        {
            Assert.That(a.Columns, Is.EqualTo(b.Columns));
            Assert.That(a.Rows, Is.EqualTo(b.Rows));

            for (int i = 0; i < a.Columns; i++)
            {
                for (int j = 0; j < a.Columns; j++)
                {
                    var diff = a[i, j] - b[i, j];
                    Assert.LessOrEqual(
                        Math.Abs(diff),
                        ComparisonPrecision
                    );
                }
            }
        });
    }
}