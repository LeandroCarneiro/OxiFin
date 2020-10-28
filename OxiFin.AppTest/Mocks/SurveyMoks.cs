using OxiFin.ViewModels.AppObjects;
using System;

namespace OxiFin.AppTest.Mocks
{
    public class SurveyMoks
    {
        public SurveyVersion_vw CreateSurvey()
        {
            return new SurveyVersion_vw()
            {
                CreatedDate = DateTime.Now,
                CreatedBy = new UserApp_vw() { },
            };
        }
    }
}
