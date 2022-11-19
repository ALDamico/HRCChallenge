using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Complex;
using System;

namespace HRCChallenge.WebService.Utils
{
    public static class MatrixUtils
    {
        public static bool IsMatrix<T>(T[] ary)
        {
            double side = Math.Sqrt(ary.Length);
            return side % 1 == 0;
        }
        public static Matrix<double> MonoDimensionalArrayToMatrix<T>(T[] ary)
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

        public static T[] FlattenBidimensionalArray<T>(T[,] matrix)
        {
            var output = new T[matrix.Length];
            var iMax = matrix.GetLength(0);
            var jMax = matrix.GetLength(1);
            var idx = 0;
            for (int i = 0; i < iMax; i++)
            {
                for (int j = 0; j < jMax; j++)
                {
                    output[idx] = matrix[i, j];
                    idx++;
                }                
            }

            return output;
        }
    }
}
