using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HRCChallenge.WebService.Responses;
using HRCChallenge.WebService.Utils;
using MathNet;
using MathNet.Numerics.LinearAlgebra;

namespace HRCChallenge.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class MatrixOperationsService : IMatrixOperationsService
    {
        public MatrixDeterminantResponse CalcDeterminant(int[] matrix)
        {
            var result = new MatrixDeterminantResponse()
            {
                IsSuccessful = true
            };
            if (!MatrixUtils.IsMatrix(matrix))
            {
                // The array is not a matrix. Let's return an error code
                result.IsSuccessful = false;
                result.ErrorDescription = "Provided array is not a matrix";
                return result;
            }

            try
            {
                // The PDF says nothing of not using open-source libraries :)
                var m = MatrixUtils.MonoDimensionalArrayToMatrix(matrix);
                var determinant = (int) Math.Round( m.Determinant(), 0);
                result.Determinant = determinant;
            }
            catch (Exception ex)
            {
                result.IsSuccessful = false;
                result.ErrorDescription = ex.Message;
            }

            return result;
        }

        public string FilterAndOrderValues(int[] matrix)
        {
            
            matrix = matrix.Distinct().ToArray();

            var temporaryList = new List<int>();
            foreach (var element in matrix)
            {
                if (element % 1 == 0)
                {
                    temporaryList.Add(element);
                } 
            }
            temporaryList.Sort();
            return string.Join(",", temporaryList);
        }
    }
}
