namespace NewtonMethodForSystem.Equation.Algebra;

public class Matrix
{
    public ref double this[int row, int column] => ref _values[row, column];
    public int Columns => _values.GetLength(1);
    public int Rows => _values.GetLength(0);

    private readonly double[,] _values;

    public Matrix(double[,] values)
    {
        _values = values;
    }

    public virtual LUMatrix LU()
    {
        for (var i = 0; i < _values.GetLength(0); i++)
        {
            // L
            for (var j = 0; j < i; j++)
            {
                double sum = 0;
                for (var k = 0; k < j; k++)
                    sum += _values[i, k] * _values[k, j];

                _values[i, j] -= sum;
                _values[i, j] /= _values[j, j];
            }

            // U
            for (var j = i; j < _values.GetLength(0); j++)
            {
                double sum = 0;
                for (var k = 0; k < i; k++)
                    sum += _values[i, k] * _values[k, j];

                _values[i, j] -= sum;
            }
        }

        return new LUMatrix(_values);
    }
}