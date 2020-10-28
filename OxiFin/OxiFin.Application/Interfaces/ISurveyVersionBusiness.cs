using OxiFin.Domain.Entities;

namespace OxiFin.Application.Interfaces
{
    public interface ISurveyVersionBusiness : IBusiness<Debtor>
    {
        void DisableVersion(long surveyId, int version);
    }
}
