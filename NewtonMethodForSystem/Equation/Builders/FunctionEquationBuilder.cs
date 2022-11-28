using NewtonMethodForSystem.Equation.Functions.Base;

namespace NewtonMethodForSystem.Equation.Builders;

public class FunctionEquationBuilder
{
    private readonly List<IDifferentiable> _functions = new();

    public FunctionEquationBuilder AddCircle(Action<CircleBuilder> action)
    {
        var builder = new CircleBuilder();
        action(builder);
        _functions.Add(builder.Build());
        return this;
    }

    public FunctionEquationBuilder AddLine(Action<LineBuilder> action)
    {
        var builder = new LineBuilder();
        action(builder);
        _functions.Add(builder.Build());
        return this;
    }

    public FunctionEquationBuilder AddSinX(Action<SinXBuilder> action)
    {
        var builder = new SinXBuilder();
        action(builder);
        _functions.Add(builder.Build());
        return this;
    }

    public FunctionalVector Build()
    {
        return new FunctionalVector(_functions.ToArray());
    }

}