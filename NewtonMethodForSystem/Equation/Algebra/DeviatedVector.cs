using System.Collections;

namespace NewtonMethodForSystem.Equation.Algebra;

public class DeviatedVector : IVector
{
    public double this[int index]
    {
        get
        {
            if (index == _deviatedValueIndex)
                return _vector[index] + _deviation;

            return _vector[index];
        }
    }
    public int Length => _vector.Length;

    private readonly IVector _vector;

    private readonly int _deviatedValueIndex;
    private readonly double _deviation;

    public DeviatedVector(IVector vector, int deviatedValueIndex, double deviation)
    {
        _vector = vector;
        _deviatedValueIndex = deviatedValueIndex;
        _deviation = deviation;
    }

    public IVector Multiply(double coefficient)
    {
        return new DeviatedVector(
            _vector * coefficient,
            _deviatedValueIndex,
            _deviation * coefficient
        );
    }

    public IEnumerator<double> GetEnumerator()
    {
        return _vector.Select((x, i) => this[i]).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}