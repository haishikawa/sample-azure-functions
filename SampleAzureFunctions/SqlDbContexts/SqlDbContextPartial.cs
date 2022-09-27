using SampleAzureFunctions.Models.Settings;
using SampleAzureFunctions.Models.Settings.IConfig;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAzureFunctions.SqlDbContexts
{
    public partial class SqlDbContext:DbContext
    {
        private readonly ISqlDbConfig _sqlDBConfig;

        public SqlDbContext(ISqlDbConfig sqlDBConfig)
        {
            _sqlDBConfig = sqlDBConfig;
            base.Database.AutoTransactionsEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_sqlDBConfig.ConnectionString);
            }
        }
    }
}
