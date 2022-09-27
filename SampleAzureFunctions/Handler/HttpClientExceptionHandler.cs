using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using SampleAzureFunctions.Exceptions;

namespace SampleAzureFunctions.Handler
{
    public class HttpClientExceptionHandler : DelegatingHandler
    {
        private readonly ILogger<HttpClientExceptionHandler> _logger;

        public HttpClientExceptionHandler(ILogger<HttpClientExceptionHandler> logger)
        {
            this._logger = logger;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var content = await (request.Content?.ReadAsStringAsync() ?? Task.FromResult(string.Empty));
            _logger.LogInformation($@"
[request],
{nameof(request.Method)}={request.Method},
{nameof(request.RequestUri)}={request.RequestUri},
{nameof(request.Headers)}={FormattingHeaders(request.Headers)}
{nameof(content)}={content}");

            var response = await base.SendAsync(request, cancellationToken);
            _logger.LogInformation($@"
[response],
{nameof(response.StatusCode)}={(int)response.StatusCode} {response.StatusCode}
{nameof(response.ReasonPhrase)}={response.ReasonPhrase}
{nameof(response.Headers)}={FormattingHeaders(response.Headers)}
{nameof(response.Content)}={await ReadContentAsUtf8StringAsync(response.Content)}");

            if (response.IsSuccessStatusCode
                || (response.StatusCode == HttpStatusCode.BadRequest && response.RequestMessage.Method == HttpMethod.Post)
                || response.StatusCode == HttpStatusCode.RequestTimeout
                || response.StatusCode == HttpStatusCode.NotFound)
            {//notfoundは呼び元に処理させる
             //Post時のbadrequestはFKErrorの場合がある リトライさせるためにここでは拾わない
                return response;
            }
            //それ以外はException発行してすべて失敗させる
            var resContent = response.Content == null ? "null" : await response.Content.ReadAsStringAsync();
            throw new HttpClientException(response.StatusCode, $"Failed Request: {response.StatusCode} {request.Method} {request.RequestUri} {resContent}");
        }

        private static string FormattingHeaders(HttpHeaders headers) => string.Join("\r\n", headers.SelectMany(x => x.Value.Select(y => $"{x.Key}:{y}"))); private static async Task<string> ReadContentAsUtf8StringAsync(HttpContent content) => Regex.Unescape(Encoding.UTF8.GetString(await content.ReadAsByteArrayAsync()));

    }
}
