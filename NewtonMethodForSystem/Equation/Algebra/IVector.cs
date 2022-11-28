namespace NewtonMethodForSystem.Equation.Algebra;

public interface IVector : IEnumerable<double>
{
    public double this[int index] { get; }
    public int Length { get; }
    public double Norm => Math.Sqrt(this.Sum(x => Math.Pow(x, 2)));
    public IVector Multiply(double coefficient);
    public IVector DeviateAt(int deviationIndex, double deviation)
    {
        return new DeviatedVector(this, deviationIndex, deviation);
    }
    public static IVector operator *(IVector vector, double coefficient) =>
        vector.Multiply(coefficient);
    public static IVector operator *(double coefficient, IVector vector) =>
        vector * coefficient;

    public static Vector operator +(IVector x, IVector y)
    {
        if (x.Length != y.Length) throw new ArgumentOutOfRangeException();
        var values = new double[x.Length];

        for (int i = 0; i < values.Length; i++)
            values[i] = x[i] + y[i];

        return new Vector(values);
    }
}