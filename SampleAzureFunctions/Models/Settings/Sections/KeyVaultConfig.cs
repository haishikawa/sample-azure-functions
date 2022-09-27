using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAzureFunctions.Models.Settings.Sections
{
    public class KeyVaultConfig
    {
        /// <summary>
        /// Azure Key VaultのURL
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// AADのテナントId
        /// </summary>
        public string TenantId { get; set; }

        /// <summary>
        /// Azure Key VaultのクライアントId
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// Azure Key Vaultのクライアントシークレット
        /// </summary>
        public string ClientSeacret { get; set; }

    }
}
