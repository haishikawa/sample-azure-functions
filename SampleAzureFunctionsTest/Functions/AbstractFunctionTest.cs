using Microsoft.AspNetCore.Http;
using Moq;
using Newtonsoft.Json;
using System.Text;

namespace SampleAzureFunctionsTest.Functions
{
    public abstract class AbstractFunctionTest
    {

        public static HttpRequest CreateRequestMock<T>(T requestBody) {
            var json = JsonConvert.SerializeObject(requestBody);
            var byteArray = Encoding.ASCII.GetBytes(json);

            var memoryStream = new MemoryStream(byteArray);
            memoryStream.Flush();
            memoryStream.Position = 0;

            var mockRequest = new Mock<HttpRequest>();
            var mockResponse = new Mock<HttpResponse>();
            mockRequest.Setup(x => x.Body).Returns(memoryStream);
            mockResponse.SetupGet(x => x.Headers).Returns((new Mock<IHeaderDictionary>()).Object);
            mockRequest.SetupGet(x => x.HttpContext.Response).Returns(mockResponse.Object);
            return mockRequest.Object;
        }
    }
}
