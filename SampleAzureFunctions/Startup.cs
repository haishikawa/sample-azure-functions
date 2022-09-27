using System;
using System.Net;
using System.Net.Http;
using SampleAzureFunctions.Handler;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Polly;
using Polly.Extensions.Http;
using MyHttpClient = SampleAzureFunctions.Clients.HttpClient;
using IMyHttpClient = SampleAzureFunctions.Clients.IClients.IHttpClient;
using SampleAzureFunctions.Models.Settings.Sections;
using SampleAzureFunctions.Services.IServices;
using SampleAzureFunctions.Clients.IClients;
using SampleAzureFunctions.Clients;
using SampleAzureFunctions.Models.Settings;
using SampleAzureFunctions.SqlDbContexts.ISqlDbContexts;
using SampleAzureFunctions.SqlDbContexts;
using System.Reflection;
using System.Linq;
using SampleAzureFunctions.Repositories.IRepositories;
using Microsoft.Extensions.Azure;
using SampleAzureFunctions.Models.Settings.IConfig;
using System.Net.Mime;
using SampleAzureFunctions.Consts;

[assembly: FunctionsStartup(typeof(SampleAzureFunctions.Startup))]
namespace SampleAzureFunctions
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var serviceProvider = builder.Services.BuildServiceProvider();

            var services = builder.Services;
            var provider = services.BuildServiceProvider();
            var config = provider.GetRequiredService<IConfiguration>();
            var assembly = Assembly.GetExecutingAssembly();

            #region KeyVault
            services.Configure<KeyVaultConfig>(config.GetSection("KeyVault"));
            services.AddScoped<IKeyVaultClient, KeyVaultClient>();
            var keyvaultClient = provider.GetService<IKeyVaultClient>();
            #endregion

            #region Config
            #region SqlDbConfig
            var sqlDbConfig = new SqlDbConfig();
#if DEBUG
            sqlDbConfig.ConnectionString = config.GetConnectionString("SqlDbConnectionString");
#else
            sqlDbConfig = keyvaultClient.GetSqlConfig();
#endif

            services.AddSingleton<ISqlDbConfig>(sqlDbConfig);
            #endregion
            #region BlobStorage
            var blobStorageConfig = new BlobStorageConfig();
#if DEBUG
            blobStorageConfig.ContainerName = config["StorageContainerName"];
            blobStorageConfig.ConnectionString = config.GetConnectionString("StorageConnectionString");
#else
                    var keyvaultClient = provider.GetService<IKeyVaultClient>();
                    blobStorageConfig  keyvaultClient.GetBlobStorageConfig();
#endif
            services.AddSingleton<IBlobStorageConfig>(blobStorageConfig);
            #endregion
            #endregion

            #region SqlDb
            services.AddScoped<ISqlDbConnect, SqlDbConnect>();
            #endregion

            #region Client
            services.AddScoped<IJWTClient, JWTClient>();
            services.AddScoped<IBlobStorageClient, BlobStorageClient>();
            #region AzureClients
            services.AddAzureClients(builder =>
            {
                // Storage Account
                builder.AddBlobServiceClient(blobStorageConfig.ConnectionString)
                .ConfigureOptions(options => options.Retry.MaxRetries = 5)
                .WithName(BlobStorageClient.blobClientName);
            });

            #endregion
            #endregion

            #region HttpClient
            services.Configure<HttpClientConfig>(config.GetSection("HttpClient"));

            services.AddTransient<HttpClientExceptionHandler>();
            services.AddHttpClient(MyHttpClient.HttpClientName, client =>
            {
                client.BaseAddress = new Uri(config["HttpClient:UriKikanSystem"]);

                client.Timeout = TimeSpan.FromSeconds(Convert.ToDouble(config["HttpClient:Timeout"]));
                client.DefaultRequestHeaders.Add(HttpKey.Accept, MediaTypeNames.Application.Json);
            })
                .AddHttpMessageHandler<HttpClientExceptionHandler>()
                .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                .AddPolicyHandler(GetRetryPolicy(int.Parse(config["HttpClient:RetryCount"])));

            services.AddScoped<IMyHttpClient, MyHttpClient>();

            #endregion

            #region Service
            foreach (var type in assembly.GetTypes().Where(mytype => mytype.GetInterfaces().Contains(typeof(IService)) && mytype.IsInterface))
            {
                var svc = assembly.GetTypes().First(mytype => mytype.GetInterfaces().Contains(type) && mytype.IsClass);
                services.AddScoped(type, svc);
            }
            #endregion

            #region Repository
            foreach (var type in assembly.GetTypes().Where(mytype => mytype.GetInterfaces().Contains(typeof(IRepository)) && mytype.IsInterface))
            {
                var repo = assembly.GetTypes().First(mytype => mytype.GetInterfaces().Contains(type) && mytype.IsClass);
                services.AddScoped(type, repo);
            }
            #endregion
        }

        /// <summary>
        /// Pollyで再試行処理を実装
        /// </summary>
        /// <param name="retryCount"></param>
        /// <returns></returns>
        private IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(int retryCount)
        {
            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == HttpStatusCode.RequestTimeout)//429でリクエストが多い場合
                .OrResult(msg => msg.StatusCode == HttpStatusCode.InternalServerError)//500エラーが発生している場合
                .OrResult(msg => msg.StatusCode == HttpStatusCode.ServiceUnavailable)//503で一時的にエラーが表示ている場合
                .WaitAndRetryAsync(retryCount, SleepDurationProviders.ExponentialBackoff());//Jitterアルゴリズムを用いてリクエストを分散
        }
    }
}