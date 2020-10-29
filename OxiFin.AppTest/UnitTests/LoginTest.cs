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
    public class LoginTest : BaseTest
    {
        protected LoginAppService _AppService;
        
        public LoginTest() : base()
        {
            _AppService = AppContainer.Resolve<LoginAppService>();
            //_AppService.Add(LoginMock.Default);
        }

        [TestMethod]
        public void LoginFail()
        {
            var mock = LoginMock.CreateLogin();
            var result = _AppService.Login(mock);

            Assert.AreEqual(result, null);
        }

        [TestMethod]
        public void LoginSuccess()
        {
            var mock = LoginMock.Default;
            var result = _AppService.Login(mock);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task LogOut()
        {
            var mock = LoginMock.Default;
            await _AppService.LogOut(mock);

            Assert.IsTrue(true);
        }
    }
}