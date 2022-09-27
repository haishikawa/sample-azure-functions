using SampleAzureFunctions.Models.Settings.IConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAzureFunctions.Models.Settings
{
    /// <summary>
    /// SQL Serverに関する設定。
    /// </summary>
    public class SqlDbConfig: ISqlDbConfig
    {
        /// <summary>
        /// SQL DBの接続文字列。
        /// </summary>
        public string ConnectionString { get; set; }
    }
}
