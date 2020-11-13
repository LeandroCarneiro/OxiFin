using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OxiFin.Application.AppServices;
using OxiFin.AppTest.Mocks;
using OxiFin.DI;
using OxiFin.ViewModels.AppObjects;
using System.Threading.Tasks;

namespace OxiFin.AppTest.UnitTests
{
    [TestClass]
    public class UserTest : BaseTest
    {
        protected UserAppService _AppService;
        
        public UserTest() : base()
        {
            _AppService = AppContainer.Resolve<UserAppService>();
        }

        [TestMethod]
        public async Task CreateAsync()
        {
            var mock = LoginMock.Default;
            var result = await _AppService.AddAsync(mock);

            Assert.IsFalse(result.HasError);
        }

        [TestMethod]
        public async Task FindAsync()
        {
            var mock = new Mock<UserApp_vw>().Object;
            var result = await _AppService.AddAsync(mock);

            var user = await _AppService.FindByIdAsync((int)result.Result);
            Assert.AreEqual(user.Result.Email, mock.Email);
        }

        [TestMethod]
        public async Task DeleteAsync()
        {
            var mock = new Mock<UserApp_vw>().Object;
            var result = await _AppService.AddAsync(mock);

            await _AppService.DesativateAsync((int)result.Result);
            Assert.IsTrue(true);
        }
    }
}