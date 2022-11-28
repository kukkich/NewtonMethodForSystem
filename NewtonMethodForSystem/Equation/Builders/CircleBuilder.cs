using NewtonMethodForSystem.Equation.Algebra;
using NewtonMethodForSystem.Equation.Functions;

namespace NewtonMethodForSystem.Equation.Builders;

public class CircleBuilder
{
    private double _radius;
    private IVector _center;

    public CircleBuilder CenterAt(params double[] center)
    {
        _center = new Vector(center);
        return this;
    }

    public CircleBuilder WithRadius(double radius)
    {
        _radius = radius;
        return this;
    }

    public CircleFunc Build()
    {
        if (_center == null) throw new InvalidOperationException();

        return new(_radius, _center);
    }
}