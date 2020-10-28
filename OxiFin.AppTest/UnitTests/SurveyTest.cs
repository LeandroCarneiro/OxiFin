using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OxiFin.Application.AppServices;
using OxiFin.DI;
using OxiFin.ViewModels.AppObjects;

namespace OxiFin.AppTest.UnitTests
{
    [TestClass]
    public class SurveyTest : BaseTest
    {
        protected SurveyVersionAppService _AppService;
        
        public SurveyTest() : base()
        {
            _AppService = AppContainer.Resolve<SurveyVersionAppService>();
        }

        [TestMethod]
        public void Create()
        {
            var mock = new Mock<SurveyVersion_vw>().Object;
            var result = _AppService.Add(mock);

            Assert.AreEqual(result, 1);
        }   
    }
}