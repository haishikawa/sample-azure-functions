using SampleAzureFunctions.Clients.IClients;
using SampleAzureFunctions.Models.Settings.IConfig;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAzureFunctions.Models.Settings
{
    public class BlobStorageConfig: IBlobStorageConfig
    {
        /// <summary>
        /// コンテナ名
        /// </summary>
        public string ContainerName { get; set; }
        /// <summary>
        /// 接続文字列
        /// </summary>
        public string ConnectionString { get; set; }
    }
}
