using OxiFin.Application.Interfaces;
using OxiFin.Domain.Entities;
using OxiFin.ViewModels.AppObjects;

namespace OxiFin.Application.AppServices
{
    public class SurveyVersionAppService : BaseAppService<SurveyVersion_vw, Debtor>
    {
        readonly ISurveyVersionBusiness _business;

        public SurveyVersionAppService(ISurveyVersionBusiness business) : base(business)
        {
            _business = business;
        }

        public override void Update(SurveyVersion_vw entity)
        {
            var newSurvey = Resolve(entity);
            _business.DisableVersion(entity.Survey.Id, entity.VersionNumber);

            newSurvey.Survey.Id = 0;
            newSurvey.VersionNumber = entity.VersionNumber + 1;
            newSurvey.Active = true;

            _baseBusiness.Add(newSurvey);
        }
    }
}
