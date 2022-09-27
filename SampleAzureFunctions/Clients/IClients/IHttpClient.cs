using SampleAzureFunctions.Models.Response;
using System.Net.Http;
using System.Threading.Tasks;

namespace SampleAzureFunctions.Clients.IClients
{
    public interface IHttpClient
    {
        public Task<SampleSearchResponseModel> SampleSearch(string userId, string kaishaCode, string password);
    }
}
