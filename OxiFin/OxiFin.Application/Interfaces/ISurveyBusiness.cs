using OxiFin.Domain.Entities;

namespace OxiFin.Application.Interfaces
{
    public interface ISurveyBusiness : IBusiness<Survey>
    {
        void DisableVersion(long surveyId, int version);
    }
}
