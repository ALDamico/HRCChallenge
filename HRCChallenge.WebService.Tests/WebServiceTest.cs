
using HRCChallenge.WebService.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HRCChallenge.WebService.Tests
{
    [TestClass]
    public class WebServiceTest
    {
        [TestMethod]
        public void TestUniqueElements()
        {
            var convertedMatrix = MatrixUtils.FlattenBidimensionalArray(matrix1);
            var response = matrixOperationsServiceClient.FilterAndOrderValues(convertedMatrix);
            Assert.AreEqual("0,2,4,8", response);
        }

        [TestMethod]
        public void TestDeterminant()
        {
            var convertedMatrix = MatrixUtils.FlattenBidimensionalArray(matrix1);
            var response = matrixOperationsServiceClient.CalcDeterminant(convertedMatrix);
            Assert.IsTrue(response.IsSuccessful);
            Assert.AreEqual(response.Determinant, 30033);
        }

        private int[,] matrix1 = new[,] {
            { 4, 9, 5, 2, 8 },
            { 8, 4, 2, 1, 3 },
            { 1, 4, 1, 8, 2 },
            { 7, 5, 9, 7, 0 },
            { 9, 3, 7, 8, 8 }
        };
        private MatrixOperationsService matrixOperationsServiceClient= new MatrixOperationsService();
    }
}
