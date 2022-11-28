namespace NewtonMethodForSystem.Equation.Functions;

public interface IFunc<out TResult, in TArgument>
{
    public TResult CalculateIn(TArgument point);
    public bool CanBeCalculatedIn(TArgument point);
}