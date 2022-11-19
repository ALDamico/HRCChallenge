using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRCChallenge.Configuration
{
    internal interface IConfigurationReader
    {
        object ConfigurationSource { get; }
        AppConfiguration ReadConfiguration();
    }
}
