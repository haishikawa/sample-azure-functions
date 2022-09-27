using System;
using System.Text.RegularExpressions;
using SampleAzureFunctions.Clients.IClients;
using SampleAzureFunctions.Consts;
using SampleAzureFunctions.Exceptions;
using SampleAzureFunctions.Models.Settings;
using JWT;
using JWT.Algorithms;
using JWT.Builder;
using JWT.Exceptions;
using JWT.Serializers;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace SampleAzureFunctions.Clients
{
    public class JWTClient: IJWTClient
    {
        private const string TokenType = "Bearer";
        private static readonly Regex _bearerRegex = new Regex($"^{TokenType}");
        #region JWT Instance
        private static readonly JsonNetSerializer _serializer = new JsonNetSerializer();
        private static readonly UtcDateTimeProvider _provider = new UtcDateTimeProvider();
        private static readonly JwtValidator _validator = new JwtValidator(_serializer, _provider);
        private static readonly JwtBase64UrlEncoder _urlEncoder = new JwtBase64UrlEncoder();
        private static readonly HMACSHA256Algorithm _algorithm = new HMACSHA256Algorithm();
        private static readonly JwtDecoder _decoder = new JwtDecoder(_serializer, _validator, _urlEncoder, _algorithm);
        #endregion
        private readonly IMemoryCache _memoryCache;
        private readonly IKeyVaultClient _keyVaultClient;
        public JWTClient(IKeyVaultClient keyVaultClient, IMemoryCache memoryCache)
        {
            _keyVaultClient = keyVaultClient;
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// ユーザーIdをpayloadに付与したJWTを作成する。
        /// </summary>
        /// <param name="userId">ユーザーId</param>
        /// <returns></returns>
        public string CreateToken(string userId)
        {
            var config = GetJWTConfig();
            return JwtBuilder.Create()
               .WithAlgorithm(new HMACSHA256Algorithm())
               .WithSecret(config.Secret)
               .AddClaim(JWTClaim.ExpiredTime, _provider.GetNow().AddMinutes(config.ExpiredTime))
               .AddClaim(JWTClaim.UserId, userId)
               .Encode();
        }

        /// <summary>
        /// Authorizationリクエストヘッダーの値を検証し、正常なトークンの場合ユーザーIdを返す
        /// </summary>
        /// <param name="token">Authorizationリクエストヘッダーの値</param>
        /// <returns>ユーザーId</returns>
        /// <exception cref="AuthException">JWTバリデーションエラー</exception>
        public string ValidateToken(string token)
        {
            token = GetBase64String(token);
            var config = GetJWTConfig();
            try//TODO:例外処理の実装
            {
                var claim = _decoder.Decode(token, config.Secret, verify: true);
                var userId = GetUserId(claim);
                return userId;
            }
            catch (TokenExpiredException e)//トークンの有効期限切れ
            {
                throw new AuthException();
            }
            catch (SignatureVerificationException e)//署名が不正
            {
                throw new AuthException();
            }
            catch (Exception e)
            {
                throw new AuthException();
            }
        }

        /// <summary>
        /// リクエストヘッダーのvalueからトークンを取得。
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private string GetBase64String(string token)
        {
            if (_bearerRegex.IsMatch(token))
            {
                token = token.Replace(TokenType, string.Empty).Trim();
            }
            return token;
        }

        /// <summary>
        /// KeyVaultからJWTの設定値を取得する。
        /// </summary>
        /// <returns></returns>
        private JWTConfig GetJWTConfig()
        {
            if (!_memoryCache.TryGetValue(CacheKey.authConfig, out JWTConfig cacheValue))
            {
                cacheValue = _keyVaultClient.GetJWTConfig();
                var thirtyMinutesExpiredOption = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(30));//30分間メモリで保持する。

                _memoryCache.Set(CacheKey.authConfig, cacheValue, thirtyMinutesExpiredOption);
            }

            return cacheValue;
        }

        private string GetUserId(string claim)
        {
            var info = JObject.Parse(claim);
            if (!info.TryGetValue(JWTClaim.UserId, out var value) && string.IsNullOrEmpty(value?.ToString()))
            {
                throw new AuthException();
            }
            else
            {
                return value.ToString();
            }
        }



    }
}
