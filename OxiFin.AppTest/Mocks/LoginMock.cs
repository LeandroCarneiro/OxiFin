using Moq;
using OxiFin.ViewModels.AppObjects;

namespace OxiFin.AppTest.Mocks
{
    public static class LoginMock
    {
        public static UserApp_vw Default = new Mock<UserApp_vw>().Object;

        public static UserApp_vw CreateLogin()
        {
            return new Mock<UserApp_vw>().Object;
        }
    }
}
