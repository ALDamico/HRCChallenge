using HRCChallenge.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRCChallenge.Configuration
{
    internal class AppConfiguration
    {
        public List<MatrixSizeViewModel> MatrixSizes { get; set; }
        public string WebServiceEndpoint { get; set; }
    }
}
