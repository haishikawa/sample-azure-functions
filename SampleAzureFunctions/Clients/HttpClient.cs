using System;
using System.Net.Http;
using Newtonsoft.Json;

using SampleAzureFunctions.Clients.IClients;
using SampleAzureFunctions.Consts;
using System.Threading.Tasks;
using SampleAzureFunctions.Models.Requests;
using System.Text;
using SampleAzureFunctions.Models.Response;
using System.Net;
using SampleAzureFunctions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace SampleAzureFunctions.Clients
{

    public class HttpClient : IHttpClient
    {
        private readonly System.Net.Http.HttpClient _client;

        public const string HttpClientName = "sampleHttpClient";
        public HttpClient(
            IHttpClientFactory clientFactory
            )
        {
            _client = clientFactory.CreateClient(HttpClientName);
        }

        public async Task<SampleSearchResponseModel> SampleSearch(string userId, string kaishaCode, string password)
        {

            var requestBody = new SampleSearchRequestModel()
            {
                検索モード = "01",
                会社コード = kaishaCode,
                ユーザーID = userId,
                パスワード = password
            };

            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(_client.BaseAddress, ApiPath.SHOKUBAN_SEARCH),
                Content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, MediaTypeNames.Application.Json)
            };

            var response = await _client.SendAsync(requestMessage);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw new HttpClientException(response.StatusCode, await response.Content.ReadAsStringAsync());
            }
            return await response.Content.ReadAsAsync<SampleSearchResponseModel>();
        }

    }
}

