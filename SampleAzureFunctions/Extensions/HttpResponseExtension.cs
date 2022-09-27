using SampleAzureFunctions.Consts;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace SampleAzureFunctions.Extensions
{
    public static class HttpResponseExtension
    {
        /// <summary>
        /// 認証トークン設定用メソッド
        /// </summary>
        /// <param name="response"></param>
        /// <param name="token"></param>
        public static void SetAuthToken(this HttpResponse response, string token)=> SetHeader(response, HttpKey.XAccessToken, token);
        
        /// <summary>
        /// SASトークン設定用メソッド
        /// </summary>
        /// <param name="response"></param>
        /// <param name="token"></param>
        public static void SetSASToken(this HttpResponse response, string token) => SetHeader(response, HttpKey.XSASToken, token);

        
        /// <summary>
        /// 複数設定用
        /// </summary>
        /// <param name="response"></param>
        /// <param name="headers"></param>
        public static void SetHeaders(this HttpResponse response, IDictionary<string, string> headers)
        {
            if (headers == null || !headers.Any()) return;

            var value = string.Empty;

            foreach (var header in headers)
            {
                value += $",{header.Key}";
                if (response.Headers.ContainsKey(header.Key))
                {
                    response.Headers[header.Key] = header.Value;
                }
                else
                {
                    response.Headers.Add(header.Key, header.Value);
                }
            }

            // 先頭のカンマを削除。
            value = value[1..];

            SetAccessControlExposeHeaders(response, value);
        }

        /// <summary>
        /// 指定されたkeyとvalueでレスポンスヘッダーに設定し、Access-Control-Expose-Headersにも追加
        /// </summary>
        /// <param name="response"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        private static void SetHeader(HttpResponse response, string key, string value)
        {
            if (response.Headers.ContainsKey(key))
            {
                response.Headers[key] = value;
            }
            else
            {
                response.Headers.Add(key, value);
            }
            SetAccessControlExposeHeaders(response, key);
        }

        /// <summary>
        /// カスタムヘッダーをAxiosで取得するために、Access-Control-Expose-Headersを追加。
        /// </summary>
        /// <param name="response"></param>
        /// <param name="key"></param>
        private static void SetAccessControlExposeHeaders(HttpResponse response, string key)
        {
            if (response.Headers.ContainsKey(HttpKey.AccessControlExposeHeaders))
            {
                response.Headers.TryGetValue(HttpKey.AccessControlExposeHeaders, out var keys);
                keys += "," + key;
                response.Headers[HttpKey.AccessControlExposeHeaders] = keys;
            }
            else
            {
                response.Headers.Add(HttpKey.AccessControlExposeHeaders, key);
            }
        }
    }


}
