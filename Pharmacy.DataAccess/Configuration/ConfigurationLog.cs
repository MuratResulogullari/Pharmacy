using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy.DataAccess.Configuration
{
    public static class ConfigurationLog
    {
        public static string GetFilePath(string name = "PostgreSQL")
        {
            string logFilePath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(logFilePath)
                .AddJsonFile("appsettings.json")
                .Build();
            return configuration.GetConnectionString("LogFilePath") ?? string.Empty;
        }
    }
}
