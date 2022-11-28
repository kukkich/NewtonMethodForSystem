using System.Collections;

namespace NewtonMethodForSystem.Equation.Algebra;

public class Vector : IVector
{
    public virtual double this[int index] => _values[index] * _coefficient;
    public int Length => _values.Length;
    public double Norm => Math.Sqrt(this.Sum(x => Math.Pow(x, 2)));

    public IVector Multiply(double coefficient)
    {
        return new Vector(_values, coefficient * _coefficient);
    }

    private readonly double[] _values;
    private readonly double _coefficient = 1;

    public Vector(params double[] values)
    {
        _values = values;
    }

    private Vector(double[] values, double coefficient)
    {
        _values = values;
        _coefficient = coefficient;
    }

    public static Vector Default(int length) => new Vector(new double[length]);

    public static Vector Filled(int length, Func<int, double> filling)
    {
        var values = new double[length];
        for (int i = 0; i < length; i++)
            values[i] = filling(i);

        return new Vector(values);
    }

    public IEnumerator<double> GetEnumerator()
    {
        return ((IEnumerable<double>)_values).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _values.GetEnumerator();
    }
}
