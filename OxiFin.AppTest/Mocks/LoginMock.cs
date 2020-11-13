using Moq;
using OxiFin.ViewModels.AppObjects;

namespace OxiFin.AppTest.Mocks
{
    public static class LoginMock
    {
        public static Login_vw Default = new Mock<Login_vw>().Object;

        public static Login_vw CreateLogin()
        {
            return new Mock<Login_vw>().Object;
        }
    }
}
