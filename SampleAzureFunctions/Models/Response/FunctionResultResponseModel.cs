using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs.Host.Executors;
using Newtonsoft.Json;
using System.Net;

namespace SampleAzureFunctions.Models.Response
{
    [JsonObject]
    public class FunctionResultResponseModel
    {
        [JsonProperty("statusCode")]
        public HttpStatusCode StatusCode { get; }

        [JsonProperty("resultCode")]
        public string ResultCode { get; }

        [JsonProperty("message")]
        public string Message { get; }

        [JsonIgnore]
        public SeverityLevel SeverityLevel { get; }

        public FunctionResultResponseModel(HttpStatusCode statusCode, string resultCode, string message, SeverityLevel level)
        {
            StatusCode = statusCode;
            ResultCode = resultCode;
            Message = message;
            this.SeverityLevel = level;
        }
        public static readonly FunctionResultResponseModel InternalServerErrorResult = new FunctionResultResponseModel(HttpStatusCode.InternalServerError, nameof(InternalServerErrorResult), "想定外のエラーが発生しました。", SeverityLevel.Critical);
        public static readonly FunctionResultResponseModel UnauthorizedResult = new FunctionResultResponseModel(HttpStatusCode.Unauthorized, nameof(UnauthorizedResult), "認証出来ませんでした。", SeverityLevel.Error);
        public static readonly FunctionResultResponseModel KeyVaultExceptionResult = new FunctionResultResponseModel(HttpStatusCode.InternalServerError, nameof(KeyVaultExceptionResult), "KeyVaultの通信処理でエラーが発生しました。", SeverityLevel.Error);
        public static readonly FunctionResultResponseModel BlobStorageException = new FunctionResultResponseModel(HttpStatusCode.InternalServerError, nameof(BlobStorageException), "BlobStorageの通信処理でエラーが発生しました。", SeverityLevel.Error);
        public static FunctionResultResponseModel ValidationExceptionResult(string validateResult) => new FunctionResultResponseModel(HttpStatusCode.BadRequest, nameof(ValidationExceptionResult), $"以下の内容でリクエスト情報のバリデーションエラーが発生しました。\n{validateResult}", SeverityLevel.Warning);
    }

}
