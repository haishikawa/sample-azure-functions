using SampleAzureFunctions.Models.Entities;
using SampleAzureFunctions.Repositories.IRepositories;
using SampleAzureFunctions.Services;
using Moq;

namespace SampleAzureFunctionsTest.Services
{
    [TestClass]
    public class MasterServiceTest
    {
        [TestMethod]
        public async Task Method1()
        {
            var repositoryMock = new Mock<IMGazoRepository>();
            var mGazoResult = new MGazo() { GazoType = "01", GazoCategory = "01", GazoTypeName = "test", GazoCategoryName = "test", CreateDate = DateTime.Now, CreatePg = "01", CreateUserId = "01",IsDelete=0 };
            IEnumerable<MGazo> getResult = new List<MGazo>();
            getResult.Append(mGazoResult);
            repositoryMock.Setup(x => x.Select()).Returns(Task.FromResult(getResult));
            var service = new MasterService(repositoryMock.Object);
            var actual = await service.GetAllMaster();
            Assert.IsNotNull(service);
            Assert.That.AreEqualClass(getResult, actual);
        }
    }
}
