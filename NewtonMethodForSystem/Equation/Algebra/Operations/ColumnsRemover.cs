namespace NewtonMethodForSystem.Equation.Algebra.Operations;

public class ColumnsRemover
{
    public Matrix RemoveExcess(Matrix matrix)
    {
        var shouldBeRemoved = GetShouldBeRemovedMask(matrix);

        var result = new Matrix(new double[matrix.Rows, matrix.Rows]);

        RemoveColumnsByMask(matrix, shouldBeRemoved, result);

        return result;
    }

    private static bool[] GetShouldBeRemovedMask(Matrix matrix)
    {
        var numberColumnsToRemove = matrix.Columns - matrix.Rows;
        var shouldBeRemoved = new bool[matrix.Columns];
        var maximumsInColumns = new IndexValue<double>[matrix.Columns];

        for (int column = 0; column < matrix.Columns; column++)
        {
            var max = MaxFromColumn(matrix, column);
            maximumsInColumns[column] = new IndexValue<double>(column, max);
        }

        var columnsThatShouldBeRemoved = maximumsInColumns
            .OrderBy(iv => iv.Value)
            .Take(numberColumnsToRemove)
            .Select(iv => iv.Index);

        foreach (var index in columnsThatShouldBeRemoved)
            shouldBeRemoved[index] = true;

        return shouldBeRemoved;
    }

    private static double MaxFromColumn(Matrix matrix, int column)
    {
        var max = double.MinValue;

        for (int row = 0; row < matrix.Rows; row++)
            if (Math.Abs(matrix[row, column]) > max)
                max = Math.Abs(matrix[row, column]);
        return max;
    }

    private static void RemoveColumnsByMask(Matrix matrix, bool[] shouldBeRemoved, Matrix result)
    {
        var columnForCopy = 0;
        for (int i = 0; columnForCopy < matrix.Rows; i++)
        {
            if (shouldBeRemoved[i]) continue;

            for (int row = 0; row < matrix.Rows; row++)
            {
                result[row, columnForCopy] = matrix[row, i];
            }

            columnForCopy++;
        }
    }


}