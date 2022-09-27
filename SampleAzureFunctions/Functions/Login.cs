using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using SampleAzureFunctions.Models.Requests;
using SampleAzureFunctions.Services.IServices;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using SampleAzureFunctions.Models.Response;
using System.Net;
using SampleAzureFunctions.Clients.IClients;
using SampleAzureFunctions.Extensions;
using System.Collections.Generic;
using SampleAzureFunctions.Consts;

namespace SampleAzureFunctions.Functions
{
    public class Login : AbstractFunction
    {
        private readonly ILoginService _loginService;
        private readonly IJWTClient _jwtClient;
        private readonly IBlobStorageClient _blobStorageClient;

        public Login(ILoginService loginService, IJWTClient jwtClient, IBlobStorageClient blobStorageClient, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _loginService = loginService;
            _jwtClient = jwtClient;
            _blobStorageClient = blobStorageClient;
        }

        [FunctionName("login")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "name" })]
        [OpenApiRequestBody(contentType: "application/json; charset=utf-8", bodyType: typeof(LoginRequestModel), Description = "LoginRequest", Required = true)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json; charset=utf-8", bodyType: typeof(LoginResponseModel), Description = "The OK response")]

        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req)
        {
            var requestBody = await req.GetBodyAsync<LoginRequestModel>();

            var result = await _loginService.Login(requestBody.UserId, requestBody.Password);
            if (result.エラーコード != "0000") return new BadRequestResult();

            //HeaderにSASトークンと認証トークンを設定
            var addHeaders = new Dictionary<string, string> {
                { HttpKey.XAccessToken, _jwtClient.CreateToken(result.USER_CODE) },
                { HttpKey.XSASToken, _blobStorageClient.GetSASUriForContainer().Query }
            };
            req.HttpContext.Response.SetHeaders(addHeaders);

            return new OkObjectResult(
                new LoginResponseModel()
                {
                    Name = result.SHIMEI,
                    KaishaName = result.SHOZOKU_KAISHA_NAME,
                    BushoName = result.SHOZOKU_BUSHO_NAME
                });
        }
    }
}
