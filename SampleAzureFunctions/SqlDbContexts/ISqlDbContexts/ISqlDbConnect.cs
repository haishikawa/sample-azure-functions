using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAzureFunctions.SqlDbContexts.ISqlDbContexts
{
    /// <summary>
    /// SQL DBの共通ロジック。
    /// </summary>
    public interface ISqlDbConnect
    {
        /// <summary>
        /// SQL DBのコンテキスト。
        /// </summary>
        public SqlDbContext Context { get; }

        /// <summary>
        /// クエリを実行。実行結果は返却しない。
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Task ExcuteQuery(Action query);

        /// <summary>
        /// クエリを実行。実行結果を返却。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="query"></param>
        /// <returns></returns>
        public Task<T> ExcuteQuery<T>(Func<T> query);

        /// <summary>
        /// トランザクション処理実施。クエリを実行。実行結果は返却しない。
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public Task ExcuteTransactionQuery(Action query);
        //    /// <summary>
        //    /// SqlDbContextセット
        //    /// </summary>
        //    public void SetContext();
    }
}
