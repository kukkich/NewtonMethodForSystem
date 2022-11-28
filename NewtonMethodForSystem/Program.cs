using NewtonMethodForSystem.Equation;
using NewtonMethodForSystem.Equation.Algebra;
using NewtonMethodForSystem.Equation.Algebra.Operations;
using NewtonMethodForSystem.Equation.Builders;
using NewtonMethodForSystem.Equation.Functions.Differentiation;

namespace NewtonMethodForSystem;

internal class Program
{
    public const double EpsF = 1e-7; // было 1e-7
    public const double EpsBetta = 1e-7;
    private const int MaxIter = 2001;
    public static IterationLogger Logger;

    private static void Main(string[] args)
    {
        IDifferentiationOperator @operator = new NumericalDifferentiationOperator();
        using var logger = new IterationLogger("C:\\Users\\vitia\\OneDrive\\Рабочий стол\\Ньютон.txt");
        Logger = logger;

        #region circle

        //.AddCircle(builder =>
        //{
        //    builder.CenterAt(0d, 0d)
        //        .WithRadius(2);
        //})
        //.AddCircle(builder =>
        //{
        //    builder.CenterAt(2d, 2d)
        //        .WithRadius(2);
        //})

        #endregion

        const double coef = 1e0;
        var functionVector = new FunctionEquationBuilder()
            .AddLine(line =>
            {
                line.Coefficients(0, 1)
                    .AndConstant(0);
            })
            .AddLine(line =>
            {
                line.Coefficients(2 * coef, 1 * coef)
                    .AndConstant(7 * coef);
            })
            .AddLine(line =>
            {
                line.Coefficients(1, -1)
                    .AndConstant(0);
            })
            .Build();
        var x = new Vector(3, -2);
        
        var fk =  -1 * functionVector.CalculateIn(x);
        var startNorm = fk.Norm;
        int i;
        double betta = 1d;
        Logger.LogIteration(0, x, fk.Norm, new Vector(0, 0), 1);

        for (i = 1;
             i < MaxIter &&
             fk.Norm / startNorm >= EpsF &&
             betta >= EpsBetta
             ; i++)
        {

            var jacobian = functionVector.Jacobian(x, @operator);

            if (jacobian.Rows < jacobian.Columns)
                jacobian = new ColumnsRemover().RemoveExcess(jacobian);
            else if (jacobian.Rows >= jacobian.Columns)
                jacobian = new RowCompressor().Compress(jacobian, ref fk);

            var deltaX = jacobian.LU().SolveEqualTo(fk);

            var xNext = FindNextX(x, deltaX, functionVector, ref betta);

            x = xNext;
            fk = -1 * functionVector.CalculateIn(x);
            Logger.LogIteration(i, x, fk.Norm, deltaX, betta);
        }
    }

    private static Vector FindNextX(Vector x, IVector deltaX, FunctionalVector functionVector, ref double betta)
    {
        betta = 1d;
        var xNext = x + betta * deltaX;
        var w = functionVector.CalculateIn(xNext);
        var wNorm = w.Norm;
        var v = 1;
        var previousFuncNorm = functionVector.CalculateIn(x).Norm;
        while (wNorm > previousFuncNorm && betta >= EpsBetta)
        {
            v++;
            betta /= 2;
            xNext = x + betta * deltaX;
            w = functionVector.CalculateIn(xNext);
            wNorm = w.Norm;
        }

        return xNext;
    }
}