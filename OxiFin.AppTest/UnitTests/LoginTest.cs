using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OxiFin.Application.AppServices;
using OxiFin.DI;
using OxiFin.ViewModels.AppObjects;
using System.Threading.Tasks;

namespace OxiFin.AppTest.UnitTests
{
    [TestClass]
    public class LoginTest : BaseTest
    {
        protected UserAppService _AppService;
        
        public LoginTest() : base()
        {
            _AppService = AppContainer.Resolve<UserAppService>();
        }

        [TestMethod]
        public void Login()
        {
            var mock = new Mock<UserApp_vw>().Object;
            var result = _AppService.Add(mock);

            Assert.AreEqual(result, 1);
        }

        [TestMethod]
        public async Task LogOut()
        {
            var mock = new Mock<UserApp_vw>().Object;
            var result = _AppService.Add(mock);

            var user = await _AppService.FindByIdAsync(result);            
            Assert.AreEqual(user.Email, mock.Email);
        }
    }
}