using SampleAzureFunctions.Clients.IClients;
using SampleAzureFunctions.Consts;
using SampleAzureFunctions.Exceptions;
using SampleAzureFunctions.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using System.Threading;
using System.Threading.Tasks;

namespace SampleAzureFunctions.Attributes
{
    internal class RequiredAuthAttribute : FunctionInvocationFilterAttribute
    {
        public override Task OnExecutingAsync(FunctionExecutingContext executingContext, CancellationToken cancellationToken)
        {
            var req = executingContext.Arguments["req"] as HttpRequest;
            var svc = req.HttpContext.RequestServices;

            if (!req.HttpContext.Request.Headers.TryGetValue(HttpKey.Authorization, out var authToken))
            {
                throw new AuthException();
            }

            var jwtClient = svc.GetService(typeof(IJWTClient)) as IJWTClient;

            var userId = jwtClient.ValidateToken(authToken);

            req.Headers.Add(HttpKey.XUserId, userId);

            //カスタムヘッダーとして認証トークンを追加
            req.HttpContext.Response.SetAuthToken(jwtClient.CreateToken(userId));

            return base.OnExecutingAsync(executingContext, cancellationToken);
        }
        public override Task OnExecutedAsync(FunctionExecutedContext executedContext, CancellationToken cancellationToken)
        {
            return base.OnExecutedAsync(executedContext, cancellationToken);
        }
    }
}

