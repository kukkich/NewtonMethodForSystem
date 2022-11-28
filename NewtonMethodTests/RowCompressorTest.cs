using NewtonMethodForSystem.Equation.Algebra;
using NewtonMethodForSystem.Equation.Algebra.Operations;

namespace NewtonMethodTests;

public class RowCompressorTest
{
    public RowCompressor Compressor;

    [SetUp]
    public void SetUp()
    {
        Compressor = new RowCompressor();
    }

    [Test]
    public void Compress6X2Test()
    {
        var target = new Matrix(new double[,]
        {
                {2, 1},
                {3, 4},
                {-1, 2},
                {11, -3},
                {2, 1},
                {-2, -4}
        });
        var rightSide = new Vector(3, -2, 1, 4, 2, -1);

        var result = Compressor.Compress(target, ref rightSide);
        var expected = new Matrix(new double[,]
        {
                {4 + 9 + 1 + 4 + 4, 1 + 16 + 4 + 1 + 16},
                {11, -3}
        });
        var expectedVector = new Vector(9 + 4 + 1 + 4 + 1, 4);

        MatrixAssert.ComparisonPrecision = 1e-14;
        Assert.Multiple(() =>
        {
            Assert.That(rightSide.Length, Is.EqualTo(expectedVector.Length));
            for (int i = 0; i < rightSide.Length; i++)
            {
                Assert.LessOrEqual(Math.Abs(rightSide[i] - expectedVector[i]), 1e-14);
            }
            MatrixAssert.Equal(result, expected);
        });
    }

    [Test]
    public void CompressShuffled6X3Test()
    {
        var target = new Matrix(new double[,]
        {
            {  1,  2,  3},
            { -5, -6,  7},
            { 13, 10,-50},
            {  9, 10,-11},
            { 17, 21, 14},
            {-13, 14, 15}
        });
        var rightSide = new Vector(4, 8, -100, 12, 200, 16);

        var result = Compressor.Compress(target, ref rightSide);


        var expected = new Matrix(new double[,]
        {
            {1 + 25 + 81 + 13*13, 4 + 36 + 100 + 14*14, 9 + 49 + 121 + 15*15},
            {13, 10, -50},
            {17, 21, 14}
        });
        var expectedVector = new Vector(
            16 + 64 + 12 * 12 + 16 * 16,
            -100,
            200
        );

        MatrixAssert.ComparisonPrecision = 1e-14;
        Assert.Multiple(() =>
        {
            Assert.That(rightSide.Length, Is.EqualTo(expectedVector.Length));
            for (int i = 0; i < rightSide.Length; i++)
            {
                Assert.LessOrEqual(Math.Abs(rightSide[i] - expectedVector[i]), 1e-14);
            }
            MatrixAssert.Equal(result, expected);
        });
    }
}