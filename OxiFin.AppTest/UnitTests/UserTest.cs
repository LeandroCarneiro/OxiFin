﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void Create()
        {
            var mock = LoginMock.Default;
            var result = _AppService.Add(mock);

            Assert.IsTrue(result > 0);
        }

        [TestMethod]
        public async Task FindAsync()
        {
            var mock = new Mock<UserApp_vw>().Object;
            var result = _AppService.Add(mock);

            var user = await _AppService.FindByIdAsync(result);            
            Assert.AreEqual(user.Email, mock.Email);
        }

        [TestMethod]
        public async Task DeleteAsync()
        {
            var mock = new Mock<UserApp_vw>().Object;
            var result = _AppService.Add(mock);

            await _AppService.DesativateAsync(result);
            Assert.IsTrue(true);
        }
    }
}