using SampleAzureFunctions.Exceptions;
using SampleAzureFunctions.Extensions;
using SampleAzureFunctions.Managers;
using SampleAzureFunctions.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SampleAzureFunctions.Functions
{
    /// <summary>
    /// ログの出力とエラーのハンドリングをまとめて実施
    /// </summary>
    public abstract class AbstractFunction : IFunctionExceptionFilter, IFunctionInvocationFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AbstractFunction(
            IHttpContextAccessor httpContextAccessor
            )
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Function開始前の処理
        /// </summary>
        /// <param name="executingContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task OnExecutingAsync(FunctionExecutingContext executingContext, CancellationToken cancellationToken)
        {
            executingContext.Logger.LogInformation($"{executingContext.FunctionName}の処理を開始します。", executingContext.Arguments);
            await Task.CompletedTask;
        }
        /// <summary>
        /// Function終了前処理
        /// </summary>
        /// <param name="executedContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task OnExecutedAsync(FunctionExecutedContext executedContext, CancellationToken cancellationToken)
        {
            executedContext.Logger.LogInformation($"{executedContext.FunctionName}の処理を正常に終了します。", executedContext.Arguments);
            await Task.CompletedTask;
        }
        /// <summary>
        /// エラー発生の処理
        /// </summary>
        /// <param name="exceptionContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task OnExceptionAsync(FunctionExceptionContext exceptionContext, CancellationToken cancellationToken)
        {
            exceptionContext.Logger.LogError($"{exceptionContext.FunctionName}の処理でエラーが発生しました。", exceptionContext.Exception.InnerException);

            await BuildErrorResponseAsync(exceptionContext.Exception.InnerException);
            await Task.CompletedTask;
        }

        /// <summary>
        /// エラー発生時のレスポンスを作成
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private async Task BuildErrorResponseAsync(Exception exception)
        {
            var result = FunctionResultResponseModel.InternalServerErrorResult; ;

            switch (exception)
            {
                case AuthException:
                    result = FunctionResultResponseModel.UnauthorizedResult;
                    break;
                case KeyVaultException:
                    result = FunctionResultResponseModel.KeyVaultExceptionResult;
                    break;
                case ValidationException:
                    var validateException = exception as ValidationException;
                    result = FunctionResultResponseModel.ValidationExceptionResult(JsonConvert.SerializeObject(validateException.validationResults));
                    break;
                case BlobStorageException:
                    result = FunctionResultResponseModel.BlobStorageException;
                    break;
            }

            var bytes = Encoding.UTF8.GetBytes(TextJsonManager.UnsafeRelaxedSerialize(result));
            _httpContextAccessor.HttpContext.Response.StatusCode = (int)result.StatusCode;
            _httpContextAccessor.HttpContext.Response.ContentType = Application.Json;
            _httpContextAccessor.HttpContext.Response.ContentLength = bytes.Length;
            await _httpContextAccessor.HttpContext.Response.Body.WriteAsync(bytes);
        }
    }
}
