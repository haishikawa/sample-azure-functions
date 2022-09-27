using SampleAzureFunctions.Models.Response;
using SampleAzureFunctions.Services.IServices;
using System.Net.Http;
using System.Threading.Tasks;
using IHttpClient = SampleAzureFunctions.Clients.IClients.IHttpClient;

namespace SampleAzureFunctions.Services
{
    public class LoginService : ILoginService
    {
        private IHttpClient _httpClient;

        public LoginService(IHttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<SampleSearchResponseModel> Login(string userId, string password)
        {　
            //ユーザーIDを用いて会社コードを作成
            var kaishaCode = userId.Substring(2, 3); 
            return await _httpClient.SampleSearch(userId, kaishaCode, password); 
        }
    }
}
