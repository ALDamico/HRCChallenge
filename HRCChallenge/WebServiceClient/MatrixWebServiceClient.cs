using HRCChallenge.MatrixOperationsService;
using HRCChallenge.WebService;
using HRCChallenge.WebService.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRCChallenge.WebServiceClient
{
    internal class MatrixWebServiceClient
    {
        public MatrixWebServiceClient(string endpoint)
        {
            webServiceEndpoint = endpoint;
            matrixOperationsServiceClient = new MatrixOperationsServiceClient(webServiceEndpoint);
        }
        private string webServiceEndpoint;
        private MatrixOperationsServiceClient matrixOperationsServiceClient;

        public MatrixDeterminantResponse CalculateDeterminant(int[,] matrix)
        {
            var flattenedArray = new int[matrix.Length];
            for (int) MatrixOperationsServiceClient
            return matrixOperationsServiceClient.CalcDeterminant(matrix);
        }

    }
}
