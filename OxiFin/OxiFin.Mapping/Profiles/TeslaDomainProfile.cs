using AutoMapper;
using OxiFin.Domain;
using OxiFin.Domain.Entities;
using OxiFin.ViewModels;
using OxiFin.ViewModels.AppObjects;

namespace OxiFin.Mapping.Profiles
{
    public class TeslaDomainProfile : Profile
    {
        public TeslaDomainProfile()
        {
            CreateMap<EntityBase<long>, EntityBase_vw<long>>().ReverseMap();
            CreateMap<UserApp, UserApp_vw>().ReverseMap();
            CreateMap<Debtor, SurveyVersion_vw>().ReverseMap();
            CreateMap<Survey, Survey_vw>().ReverseMap();
            CreateMap<Answer, Answer_vw>().ReverseMap();
            CreateMap<Question, Question_vw>().ReverseMap();
        }
    }
}
