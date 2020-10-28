using OxiFin.Application.Interfaces;
using OxiFin.Domain.Entities;
using OxiFin.ViewModels.AppObjects;

namespace OxiFin.Application.AppServices
{
    public class SurveyAppService : BaseAppService<Survey_vw, Survey>
    {
        readonly ISurveyBusiness _business;

        public SurveyAppService(ISurveyBusiness business) : base(business)
        {
            _business = business;
        }
    }
}
