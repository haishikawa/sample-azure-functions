using SampleAzureFunctions.Clients.IClients;
using SampleAzureFunctions.Exceptions;
using SampleAzureFunctions.Models.Settings.IConfig;
using Azure.Storage.Blobs;
using Azure.Storage.Sas;
using Microsoft.Extensions.Azure;
using System;

namespace SampleAzureFunctions.Clients
{
    public class BlobStorageClient : IBlobStorageClient
    {
        public const string blobClientName = "AzukarishoBlobClient";
        private readonly IBlobStorageConfig _blobStorageConfig;
        private readonly BlobServiceClient _blobServiceClient;
        public BlobStorageClient(IBlobStorageConfig blobStorageConfig, IAzureClientFactory<BlobServiceClient> azureClientFactory)
        {
            _blobStorageConfig = blobStorageConfig;
            _blobServiceClient = azureClientFactory.CreateClient(blobClientName);
        }

        public Uri GetSASUriForContainer(string storedPolicyName = null)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient(_blobStorageConfig.ContainerName);

            if (containerClient.CanGenerateSasUri)
            {
                var sasBuilder = new BlobSasBuilder()
                {
                    BlobContainerName = containerClient.Name,
                    Resource = "c"
                };

                if (storedPolicyName == null)
                {
                    sasBuilder.ExpiresOn = DateTimeOffset.UtcNow.AddHours(1);//1時間のみ有効
                    sasBuilder.SetPermissions(BlobContainerSasPermissions.Read);//読み込み権限のみ有効
                }
                else
                {
                    sasBuilder.Identifier = storedPolicyName;
                }

                return containerClient.GenerateSasUri(sasBuilder);
            }
            else
            {
                throw new BlobStorageException();
            }
        }
    }
}
