using SampleAzureFunctions.Clients.IClients;
using SampleAzureFunctions.Models.Response;
using SampleAzureFunctions.Services;
using Moq;

namespace SampleAzureFunctionsTest.Services
{
    [TestClass]
    public class LoginServiceTest
    {
        private string _testUserId = "00 0000000";
        private string _testPassword = "P@ssw0rd";
        #region 正常系
        [TestMethod]
        public async Task 正常()
        {
            var httpClientMock = new Mock<IHttpClient>();
            var responseResult = new SampleSearchResponseModel()
            {
                USER_CODE = "テストユーザーID",
                SHIMEI = "テストユーザー",
                SHOKUBAN_LEVELE = "テストユーザーレベル",
                SHOZOKU_KAISHA_CODE = "テスト会社コード",
                SHOZOKU_KAISHA_NAME = "テスト会社名",
                SHOZOKU_BUSHO_CODE = "テスト部署コード",
                SHOZOKU_BUSHO_NAME = "テスト部署名",
                エラーコード = "0000"
            };
            httpClientMock.Setup(x => x.SampleSearch(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(responseResult));
            var service = new LoginService(httpClientMock.Object);
            var actual =await service.Login(_testUserId, _testPassword);
            Assert.IsNotNull(service);
            Assert.That.AreEqualClass(responseResult, actual);
        }
        #endregion
        #region エラー系
        [TestMethod]
        public async Task エラー_レスポンス_null()
        {
            var httpClientMock = new Mock<IHttpClient>();
            var responseResult = new SampleSearchResponseModel()
            {
                USER_CODE = "テストユーザーID",
                SHIMEI = "テストユーザー",
                SHOKUBAN_LEVELE = "テストユーザーレベル",
                SHOZOKU_KAISHA_CODE = "テスト会社コード",
                SHOZOKU_KAISHA_NAME = "テスト会社名",
                SHOZOKU_BUSHO_CODE = "テスト部署コード",
                SHOZOKU_BUSHO_NAME = "テスト部署名",
                エラーコード = "0000"
            };
            httpClientMock.Setup(x => x.SampleSearch(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult<SampleSearchResponseModel>(null));
            var service = new LoginService(httpClientMock.Object);
            var actual = await service.Login(_testUserId, _testPassword);
            Assert.IsNull(actual);
        }
        #endregion
    }
}
