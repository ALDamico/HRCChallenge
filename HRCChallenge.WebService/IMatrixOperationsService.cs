using HRCChallenge.WebService.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HRCChallenge.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IMatrixOperationsService
    {
        [OperationContract]
        MatrixDeterminantResponse CalcDeterminant(int[] matrix);

        [OperationContract]
        string FilterAndOrderValues(int[] matrix);
    }

  
}
