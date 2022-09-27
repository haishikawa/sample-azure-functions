using SampleAzureFunctions.Consts;
using SampleAzureFunctions.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ValidationException = SampleAzureFunctions.Exceptions.ValidationException;

namespace SampleAzureFunctions.Extensions
{
    public static class HttpRequestExtension
    {
        /// <summary>
        /// JWT認証中に設定されたユーザーIdをリクエスト情報から取得する。
        /// </summary>
        /// <param name="request"></param>
        /// <returns>ユーザーId</returns>
        /// <exception cref="AuthException"></exception>
        public static string GetUserId(this HttpRequest request)
        {
            if (!request.Headers.TryGetValue(HttpKey.XUserId, out var userIdValues))
            {
                throw new AuthException();
            }
            return userIdValues.First();
        }

        /// <summary>
        /// リクエストボディを取得し、バリデーションが正常に実施された場合のみ返却する。
        /// </summary>
        /// <typeparam name="T">リクエストボディのモデル</typeparam>
        /// <param name="request">バリデーション済みのリクエストボディ</param>
        /// <returns></returns>
        public static async Task<T> GetBodyAsync<T>(this HttpRequest request)
        {
            var requestBodyStr = await request.ReadAsStringAsync();
            return GetValidRequest<T>(requestBodyStr);
        }

        /// <summary>
        /// リクエスト情報からクエリパラメータを取得し、バリデーションが正常に実施された場合のみ返却する。
        /// </summary>
        /// <typeparam name="T">クエリパラメータのモデル</typeparam>
        /// <param name="request">バリデーション済みのクエリパラメータ</param>
        /// <returns></returns>
        public static T GetQueryParam<T>(this HttpRequest request)
        {
            string requestQueryParametersStr = JsonConvert.SerializeObject(request.GetQueryParameterDictionary());
            return GetValidRequest<T>(requestQueryParametersStr);
        }

        /// <summary>
        /// モデルの<see cref="ValidationAttribute"/>をもとにバリデーションを実施する。<br/>
        /// バリデーションが正常に完了しなかった場合、<see cref="ValidationException"/>をthrowする。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="res"></param>
        /// <returns>バリデーション済みのリクエストモデル</returns>
        /// <exception cref="ValidationException"></exception>
        private static T GetValidRequest<T>(string requestStr)
        {
            var body = JsonConvert.DeserializeObject<T>(requestStr);

            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(body, new ValidationContext(body, null, null), results, true)) {
                throw new ValidationException() { validationResults = results };
            }
            return body;
        }
    }
}
