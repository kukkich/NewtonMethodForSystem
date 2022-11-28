namespace NewtonMethodForSystem.Equation.Algebra.Operations;

public record IndexValue<T>
{
    public int Index { get; set; }
    public T Value { get; set; }

    public IndexValue(int index, T value)
    {
        Index = index;
        Value = value;
    }
}