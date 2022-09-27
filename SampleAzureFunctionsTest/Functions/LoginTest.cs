using SampleAzureFunctions.Clients.IClients;
using SampleAzureFunctions.Functions;
using SampleAzureFunctions.Models.Requests;
using SampleAzureFunctions.Models.Response;
using SampleAzureFunctions.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SampleAzureFunctions.Exceptions;

namespace SampleAzureFunctionsTest.Functions
{
    [TestClass]
    public class LoginTest : AbstractFunctionTest
    {
        #region 正常系
        [TestMethod]
        public async Task 正常()
        {
            var loginService = new Mock<ILoginService>();
            var returnShokubanSearch
                = new SampleSearchResponseModel()
                {
                    SHIMEI = "テストユーザー",
                    SHOZOKU_KAISHA_NAME = "テスト会社名",
                    SHOZOKU_BUSHO_NAME = "テスト部署名",
                    エラーコード = "0000"
                };

            loginService.Setup((x) => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(returnShokubanSearch));
            var jwtClient = new Mock<IJWTClient>();
            var blobStorageClient = new Mock<IBlobStorageClient>();
            blobStorageClient.Setup(x => x.GetSASUriForContainer(It.IsAny<string>())).Returns(new Uri("http://test-sas-token"));
            var httpContextAccessor = new Mock<IHttpContextAccessor>();

            //Loginのインスタンスを作成
            var loginFunctions = new Login(loginService.Object, jwtClient.Object, blobStorageClient.Object, httpContextAccessor.Object);

            var requestBody = new LoginRequestModel() { UserId = "0001 0000", Password = "P@ssw0rd" };

            var actual = await loginFunctions.Run(CreateRequestMock(requestBody));

            var expected = new OkObjectResult(
                new LoginResponseModel()
                {
                    Name = returnShokubanSearch.SHIMEI,
                    KaishaName = returnShokubanSearch.SHOZOKU_KAISHA_NAME,
                    BushoName = returnShokubanSearch.SHOZOKU_BUSHO_NAME
                });
            Assert.IsNotNull(actual);
            Assert.That.AreEqualClass(expected, actual);
        }
        #endregion

        #region　エラー系
        [TestMethod]
        public async Task エラー_ユーザー検索APIに存在しないアカウント()
        {
            var loginService = new Mock<ILoginService>();
            var returnShokubanSearch
                = new SampleSearchResponseModel()
                {
                    SHIMEI = "テストユーザー",
                    SHOZOKU_KAISHA_NAME = "テスト会社名",
                    SHOZOKU_BUSHO_NAME = "テスト部署名",
                    エラーコード = "9999"
                };

            loginService.Setup((x) => x.Login(It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(returnShokubanSearch));
            var jwtClient = new Mock<IJWTClient>();
            var blobStorageClient = new Mock<IBlobStorageClient>();
            blobStorageClient.Setup(x => x.GetSASUriForContainer(It.IsAny<string>())).Returns(new Uri("http://test-sas-token"));
            var httpContextAccessor = new Mock<IHttpContextAccessor>();

            //Loginのインスタンスを作成
            var loginFunctions = new Login(loginService.Object, jwtClient.Object, blobStorageClient.Object, httpContextAccessor.Object);

            var requestBody = new LoginRequestModel() { UserId = "0001 0000", Password = "P@ssw0rd" };

            var actual = await loginFunctions.Run(CreateRequestMock(requestBody));

            var expected = new BadRequestResult();
            Assert.IsNotNull(actual);
            Assert.That.AreEqualClass(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        [DataRow("","")]
        [DataRow("",null)]
        [DataRow("", "P@ssw0rd")]
        [DataRow(null,"")]
        [DataRow(null,null)]
        [DataRow(null,"P@ssw0rd")]
        [DataRow("9桁以上の文字を入力します。", "")]
        [DataRow("9桁以上の文字を入力します。", null)]
        [DataRow("9桁以上の文字を入力します。", "P@ssw0rd")]
        //TODO:パスワードの桁数チェックに合わせて追加する可能性あり
        public async Task エラー_リクエストのバリデーションエラー(string userId,string password)
        {
            var requestBody = new LoginRequestModel() { UserId = userId, Password = password };
            var loginService = new Mock<ILoginService>();
            var jwtClient = new Mock<IJWTClient>();
            var blobStorageClient = new Mock<IBlobStorageClient>();
            var httpContextAccessor = new Mock<IHttpContextAccessor>();

            //Loginのインスタンスを作成
            var loginFunctions = new Login(loginService.Object, jwtClient.Object, blobStorageClient.Object, httpContextAccessor.Object);

            await loginFunctions.Run(CreateRequestMock(requestBody));
        }
        #endregion
    }
}
