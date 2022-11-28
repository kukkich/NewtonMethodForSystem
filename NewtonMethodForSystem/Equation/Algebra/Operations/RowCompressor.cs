namespace NewtonMethodForSystem.Equation.Algebra.Operations;

public class RowCompressor
{
    public Matrix Compress(Matrix matrix, ref IVector rightSide)
    {
        var numberRowsToCompress = matrix.Rows - matrix.Columns + 1;
        var shouldBeCompressed = GetShouldBeCompressedMask(rightSide, numberRowsToCompress);

        int notCompressedRowIndex = 1;
        var result = new Matrix(new double[matrix.Columns, matrix.Columns]);
        var compressedRightSide = new double[matrix.Columns];

        for (int i = 0; i < shouldBeCompressed.Length; i++)
        {
            if (!shouldBeCompressed[i])
            {
                for (var j = 0; j < matrix.Columns; j++)
                    result[notCompressedRowIndex, j] = matrix[i, j];
                compressedRightSide[notCompressedRowIndex] = rightSide[i];

                notCompressedRowIndex++;
                continue;
            }

            for (int j = 0; j < matrix.Columns; j++)
                result[0, j] += Math.Pow(matrix[i, j], 2);
            compressedRightSide[0] += Math.Pow(rightSide[i], 2);
        }

        rightSide = new Vector(compressedRightSide);
        return result;
    }

    private static bool[] GetShouldBeCompressedMask(IVector rightSie, int numberRowsToCompress)
    {
        var mask = new bool[rightSie.Length];
        var rowIndexesThatShouldBeCompressed = rightSie
            .Select((x, i) => new IndexValue<double>(i, x))
            .OrderBy(iv => Math.Abs(iv.Value))
            .Take(numberRowsToCompress)
            .Select(iv => iv.Index);

        foreach (var index in rowIndexesThatShouldBeCompressed)
            mask[index] = true;

        return mask;
    }
}