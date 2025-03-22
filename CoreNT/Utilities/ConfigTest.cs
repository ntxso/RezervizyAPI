using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreNT.Utilities
{
    public class ConfigTest
    {

        static string curVal;
        static string altVal;
        static string primaryVal;
        private IConfiguration _configuration;
        public ConfigTest(IConfiguration configuration)
        {
            _configuration = configuration;
            string hostName = System.Net.Dns.GetHostName();
            string sqlConStr = (hostName == "IstChiaMain" || hostName == "Lenovont") ? "Local" : "Ozkula";
            //primaryVal = configuration.GetConnectionString(sqlConStr);
            curVal = (primaryVal = configuration.GetConnectionString(sqlConStr)).Replace("\\\\","\\");
            altVal = configuration.GetConnectionString("Turhost").Replace("\\\\", "\\");
        }
        public void SetConnectionString(string jsonFieldName)
        {
            curVal= _configuration.GetConnectionString(jsonFieldName).Replace("\\\\", "\\");
        }
        public static string CurrentConnection
        {
            get
            {
                return curVal;
            }
        }
        public string Value
        {
            get
            {
                return curVal;
            }
        }
        public void SetPrimaryDb()
        {
            curVal = primaryVal;
        }
        public void SetAlternativeDb()
        {
            curVal = altVal;
        }
    }
}
