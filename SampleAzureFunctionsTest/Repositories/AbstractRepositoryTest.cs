using SampleAzureFunctions.Models.Settings;
using SampleAzureFunctions.Models.Settings.IConfig;
using SampleAzureFunctions.SqlDbContexts;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace SampleAzureFunctionsTest.Repositories
{
    public abstract class AbstractRepositoryTest: AbstractTest
    {
        /// <summary>
        /// テスト用SqlDbConnect
        /// </summary>
        protected SqlDbConnect SqlDbConnect { get; private set; }

  
        [TestInitialize]
        public void Initialize()
        {
            
            var _logger = new Mock<ILogger<SqlDbConnect>>();
            SqlDbConnect = new SqlDbConnect(SqlDBConfig, _logger.Object);
            
        }
    }
}
