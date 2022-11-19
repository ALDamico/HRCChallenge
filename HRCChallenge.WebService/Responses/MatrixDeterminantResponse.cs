using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HRCChallenge.WebService.Responses
{
    [DataContract]
    public class MatrixDeterminantResponse
    {
        [DataMember]
        public bool IsSuccessful { get; set; }
        [DataMember]
        public int? Determinant { get; set; }
        [DataMember]
        public string ErrorDescription { get; set; }
    }
}
