using SampleAzureFunctions.Repositories;

namespace SampleAzureFunctionsTest.Repositories
{
    [TestClass]
    public class MGazoRepositoryTest:AbstractRepositoryTest
    {
        #region　正常
        [TestMethod]
        public async Task 正常() {
            var repository = new MGazoRepository(SqlDbConnect);
            var result = await repository.Select();
            Assert.IsNotNull(result);
        }
        #endregion
    }
}
