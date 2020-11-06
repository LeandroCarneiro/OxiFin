using AutoMapper;
using OxiFin.Domain;
using OxiFin.Domain.Entities;
using OxiFin.Domain.Entities.Auth;
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
            CreateMap<Debtor, Debtor_vw>().ReverseMap();
        }
    }
}
