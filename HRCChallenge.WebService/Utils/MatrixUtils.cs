using MathNet.Numerics.LinearAlgebra;
using System;

namespace HRCChallenge.WebService.Utils
{
    internal static class MatrixUtils
    {
        internal static bool IsMatrix<T>(T[] ary)
        {
            double side = Math.Sqrt(ary.Length);
            return side % 1 == 0;
        }
        internal static Matrix<double> MonoDimensionalArrayToMatrix<T>(T[] ary)
        {
            int side = (int)Math.Sqrt(ary.Length);
            var convertedMatrix = new double[side, side];
            int i = 0;
            int j = 0;

            for (int x = 0; x < ary.Length; x++)
            {
                if (j == side)
                {
                    j = 0;
                    i++;
                }

                convertedMatrix[i, j] = Convert.ToDouble(ary[x]);
                j++;
            }
            return Matrix<double>.Build.DenseOfArray(convertedMatrix);
        }
    }
}
