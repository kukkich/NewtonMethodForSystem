using NewtonMethodForSystem.Equation.Algebra;
using NewtonMethodForSystem.Equation.Functions;
using NewtonMethodForSystem.Equation.Functions.Base;
using NewtonMethodForSystem.Equation.Functions.Differentiation;

namespace NewtonMethodForSystem.Equation;

public class FunctionalVector : IFunc<IVector, IVector>
{
    private readonly IDifferentiable[] _functions;

    public IDifferentiable this[int index] => _functions[index];

    public FunctionalVector(params IDifferentiable[] functions)
    {
        _functions = functions;
    }

    public Matrix Jacobian(Vector point, IDifferentiationOperator @operator)
    {
        if (!_functions.All(f => f.CanBeCalculatedIn(point)))
            throw new ArgumentOutOfRangeException(nameof(point));

        var jacobian = new double[_functions.Length, point.Length];

        for (int i = 0; i < _functions.Length; i++)
            for (int j = 0; j < point.Length; j++)
                jacobian[i, j] = _functions[i]
                    .DerivativeBy(@operator, j)
                    .CalculateIn(point);

        return new Matrix(jacobian);
    }

    public IVector CalculateIn(IVector point) =>
        new Vector(_functions.Select(f => f.CalculateIn(point))
            .ToArray());

    public bool CanBeCalculatedIn(IVector point) =>
        _functions.All(f => f.CanBeCalculatedIn(point));
}