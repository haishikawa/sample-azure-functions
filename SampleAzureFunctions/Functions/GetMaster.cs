using System.IO;
using System.Net;
using System.Threading.Tasks;
using SampleAzureFunctions.Attributes;
using SampleAzureFunctions.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace SampleAzureFunctions.Functions
{
    public class GetMaster : AbstractFunction
    {
        private readonly ILogger<GetMaster> _logger;
        private readonly IMasterService _service;

        public GetMaster(IMasterService service, ILogger<GetMaster> log, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
        {
            _service = service;
            _logger = log;
        }

        [RequiredAuth]
        [FunctionName("GetMaster")]
        [OpenApiOperation(operationId: "Run", tags: new[] { "name" })]
        [OpenApiSecurity("Bearer", SecuritySchemeType.Http, Name = "authorization", Scheme = OpenApiSecuritySchemeType.Bearer, In = OpenApiSecurityLocationType.Header, BearerFormat = "JWT")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/plain", bodyType: typeof(string), Description = "The OK response")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {

            var result = await _service.GetAllMaster();

            return new OkObjectResult(result);
        }
    }
}

