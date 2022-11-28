using NewtonMethodForSystem.Equation.Algebra;

namespace NewtonMethodTests
{
    internal class LUTest
    {
        public Matrix Matrix;

        [SetUp]
        public void SetUp()
        {
            Matrix = new Matrix(new double[,]
            {
                {3, 2, 3, 1},
                {2, 2, 1, 5},
                {2, 1, 4, 4},
                {5, 1, 4, 5}
            });
        }

        [Test]
        public void LU4X4SolutionTest()
        {
            var solution = Matrix.LU().SolveEqualTo(new Vector(20, 29, 32, 39));
            var expected = new Vector(1, 2, 3, 4);
            Assert.Multiple(() =>
            {
                for (int i = 0; i < solution.Length; i++)
                {
                    Assert.LessOrEqual(Math.Abs(solution[i] - expected[i]), 1e-7);
                }
            });

        }
    }
}
