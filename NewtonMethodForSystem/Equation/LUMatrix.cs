using NewtonMethodForSystem.Equation.Algebra;

namespace NewtonMethodForSystem.Equation;

public class LUMatrix
{
    private readonly double[,] _values;

    public LUMatrix(double[,] values)
    {
        _values = values;
    }

    // TODO Протестировать
    public IVector SolveEqualTo(IVector rightSide)
    {
        if (rightSide.Length != _values.GetLength(0))
            throw new ArgumentOutOfRangeException();

        var y = new double[rightSide.Length];
        var x = new double[rightSide.Length];

        // Прямой ход
        for (var i = 0; i < rightSide.Length; i++)
        {
            var sum = 0d;
            for (var j = 0; j < i; j++)
            {
                sum += _values[i, j] * y[j];
            }

            y[i] = rightSide[i] - sum;
        }

        // Обратный ход
        for (var i = rightSide.Length - 1; i >= 0; i--)
        {
            var sum = 0d;
            for (var j = rightSide.Length - 1; j > i; j--)
            {
                sum += _values[i, j] * x[j];
            }

            x[i] = (y[i] - sum) / _values[i, i];
        }

        return new Vector(x);
    }
}