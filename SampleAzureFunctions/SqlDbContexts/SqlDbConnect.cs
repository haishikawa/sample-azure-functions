using SampleAzureFunctions.Exceptions;
using SampleAzureFunctions.Models.Settings;
using SampleAzureFunctions.Models.Settings.IConfig;
using SampleAzureFunctions.SqlDbContexts.ISqlDbContexts;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace SampleAzureFunctions.SqlDbContexts
{ /// <summary>
  /// SQL DBの共通ロジック。
  /// </summary>
    public class SqlDbConnect : ISqlDbConnect
    {
        private const string _startMessage = "Start sqlDb connecting";
        private const string _endMessage = "End sqlDb connecting";
        public SqlDbContext Context { get; private set; }

        private readonly ISqlDbConfig _sqlDBConfig;
        private readonly ILogger<SqlDbConnect> _logger;
        public SqlDbConnect(
            ISqlDbConfig config,
            ILogger<SqlDbConnect> logger)
        {
            _sqlDBConfig = config;
            _logger = logger;
        }

        /// <summary>
        /// クエリを実行。実行結果は返却しない。
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Task ExcuteQuery(Action query)
        {
            _logger.LogTrace(_startMessage);

            try
            {
                using (Context = new SqlDbContext(_sqlDBConfig))
                {
                    query();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new SqlDbException(e);
            }
            finally
            {
                _logger.LogTrace(_endMessage);
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// クエリを実行。実行結果を返却。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public Task<T> ExcuteQuery<T>(Func<T> query)
        {
            _logger.LogTrace(_startMessage, SeverityLevel.Information);

            T result = default;

            try
            {
                using (Context = new SqlDbContext(_sqlDBConfig))
                {
                    result = query();
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message,e);
                throw new SqlDbException(e);
            }
            finally
            {
                _logger.LogTrace(_endMessage, SeverityLevel.Information);
            }

            return Task.FromResult(result);
        }

        /// <summary>
        /// クエリを実行。実行結果は返却しない。
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task ExcuteTransactionQuery(Action query)
        {
            _logger.LogTrace(_startMessage, SeverityLevel.Information);

            try
            {
                using (Context = new SqlDbContext(_sqlDBConfig))
                using (var transaction = await Context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        query();
                        await transaction.CommitAsync();

                    }
                    catch (Exception e)
                    {
                        await transaction.RollbackAsync();
                        throw new SqlDbException(e);
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message, e);
                throw new SqlDbException(e);
            }
            finally
            {
                _logger.LogTrace(_endMessage, SeverityLevel.Information);
            }
        }

        ///// <summary>
        ///// SqlDbContextセット
        ///// </summary>
        //public void SetContext()
        //{
        //    Context = new SqlDbContext(_sqlDBConfig);
        //}
    }
}
