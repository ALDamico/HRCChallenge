﻿using HRCChallenge.MatrixOperationsService;
using HRCChallenge.WebService.Responses;
using HRCChallenge.WebService.Utils;

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
            var flattenedArray = MatrixUtils.FlattenBidimensionalArray(matrix);
            
            return matrixOperationsServiceClient.CalcDeterminant(flattenedArray);
        }

        public string FilterAndOrderElements(int[,] matrix)
        {
            var flattenedArray = MatrixUtils.FlattenBidimensionalArray(matrix);
            return matrixOperationsServiceClient.FilterAndOrderValues(flattenedArray);
        }

    }
}
