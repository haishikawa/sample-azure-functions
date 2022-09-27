using System;
using System.Net;

namespace SampleAzureFunctions.Exceptions
{
    [Serializable]
    public class HttpClientException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; }

        public HttpClientException(HttpStatusCode httpStatusCode, string message) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
