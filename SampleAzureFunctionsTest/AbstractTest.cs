using SampleAzureFunctions.Models.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SampleAzureFunctionsTest
{

    public class AbstractTest
    {
        public ServiceCollection Service = new ServiceCollection();
        public ServiceProvider Provider;
        public IConfiguration Config;
        public SqlDbConfig SqlDBConfig = new SqlDbConfig();

        public AbstractTest()
        {
            Provider = Service.AddLogging().BuildServiceProvider();
            var env = string.IsNullOrEmpty(Environment.GetEnvironmentVariable("TestEnvironment")) ? "local" : Environment.GetEnvironmentVariable("TestEnvironment");
            var configFile = $"{env}.settings.json";

            Config = new ConfigurationBuilder().AddJsonFile(configFile).Build();

            SqlDBConfig.ConnectionString = Config.GetConnectionString("SqlDbConnectionString");
        }
    }
}
