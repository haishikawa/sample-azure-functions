using SampleAzureFunctions.Clients.IClients;
using SampleAzureFunctions.Consts;
using SampleAzureFunctions.Exceptions;
using SampleAzureFunctions.Models.Settings;
using SampleAzureFunctions.Models.Settings.Sections;
using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Options;
using System;

namespace SampleAzureFunctions.Clients
{
    public class KeyVaultClient : IKeyVaultClient
    {
        private readonly KeyVaultConfig _config;
        public KeyVaultClient(IOptions<KeyVaultConfig> config)
        {
            _config = config.Value;
        }

        public JWTConfig GetJWTConfig()
        {
            #region ローカル実行処理
#if DEBUG
            return new JWTConfig()
            {
                Secret = "UqXA2MbB1EMvIZ9biGAMD+gy7HMflfyZEbfub5qL",//次のコマンドで生成=>[openssl rand -base64 30]
                ExpiredTime = 30.0,
            };
#endif
            #endregion
            try
            {
                var client = CreateSecretClient();
                return new JWTConfig()
                {
                    Secret = ((KeyVaultSecret)client.GetSecret(KeyVaultKey.JWTSecret))?.Value,
                    ExpiredTime = double.Parse(((KeyVaultSecret)client.GetSecret(KeyVaultKey.JWTExpiredTime))?.Value),
                };
            }
            catch (Exception e)
            {
                throw new KeyVaultException();
            }
        }

        public SqlDbConfig GetSqlConfig()
        {
            try
            {
                var client = CreateSecretClient();
                return new SqlDbConfig()
                {
                    ConnectionString = ((KeyVaultSecret)client.GetSecret(KeyVaultKey.SqlDbConnectionString))?.Value
                };
            }
            catch (Exception e)
            {
                throw new KeyVaultException();
            }
        }
        public BlobStorageConfig GetBlobStorageConfig()
        {
            try
            {
                var client = CreateSecretClient();
                return new BlobStorageConfig()
                {
                    ContainerName = ((KeyVaultSecret)client.GetSecret(KeyVaultKey.StorageContainerName))?.Value,
                    ConnectionString = ((KeyVaultSecret)client.GetSecret(KeyVaultKey.StorageConnectionString))?.Value
                };
            }
            catch (Exception e)
            {
                throw new KeyVaultException();
            }
        }


        private SecretClient CreateSecretClient()
        {
            var credential = new ClientSecretCredential(_config.TenantId, _config.ClientId, _config.ClientSeacret);
            var options = new SecretClientOptions()
            {
                Retry =
                {
                    Delay= TimeSpan.FromSeconds(3),
                    MaxDelay = TimeSpan.FromSeconds(60),
                    MaxRetries = 5,
                    Mode = RetryMode.Fixed,
                 }
            };
            return new SecretClient(new Uri(_config.Url), credential, options);
        }
    }
}
