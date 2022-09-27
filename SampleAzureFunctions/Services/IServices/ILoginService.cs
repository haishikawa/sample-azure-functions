using SampleAzureFunctions.Models.Response;
using System.Threading.Tasks;

namespace SampleAzureFunctions.Services.IServices
{
    public interface ILoginService: IService
    {
        public Task<SampleSearchResponseModel> Login(string userId, string password);
    }
}
