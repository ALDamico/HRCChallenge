using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRCChallenge.Configuration
{
    internal class JsonConfigurationReader : IConfigurationReader
    {
        public JsonConfigurationReader(string jsonFile)
        {
            ConfigurationSource = jsonFile;
        }

        public object ConfigurationSource { get; }

        public AppConfiguration ReadConfiguration()
        {
            var jsonContent = File.ReadAllText(ConfigurationSource.ToString());
            var config = JsonConvert.DeserializeObject<AppConfiguration>(jsonContent);
            return config;
        }
    }
}
