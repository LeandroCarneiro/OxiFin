using OxiFin.Application.Interfaces;
using OxiFin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OxiFin.Business.Domain
{
    public class SurveyBusiness : AppBusiness<Debtor>, ISurveyVersionBusiness
    {
        public override IQueryable<Debtor> SetIncluding => (Set.Include(x => x.Survey).ThenInclude(s => s.Questions).ThenInclude(a => a.Answers).Include(y => y.CreatedBy)).AsNoTracking();
        public override IQueryable<Debtor> SetIncludingTracking => (Set.Include(x => x.Survey).ThenInclude(s => s.Questions).ThenInclude(a => a.Answers).Include(y => y.CreatedBy)).AsTracking();

        public void DisableVersion(long surveyId, int version)
        {
            using (var trans = _uow.BeginTransaction())
            {
                var versionSurvey = Find(x => x.VersionNumber == version && x.SurveyId == surveyId);
                versionSurvey.Active = false;
                trans.Commit();

                _uow.Commit();
            }
        }
    }
}
