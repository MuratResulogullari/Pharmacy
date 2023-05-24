using Microsoft.Extensions.Configuration;

namespace Pharmacy.DataAccess.Configuration
{
    public static class ConfigurationConnectionDatabase
    {
        public static string GetConnecxtionString(string name = "PostgreSQL")
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                .AddJsonFile("appsettings.json")
                .Build();
            return configuration.GetConnectionString(name) ?? string.Empty;
        }
    }
}