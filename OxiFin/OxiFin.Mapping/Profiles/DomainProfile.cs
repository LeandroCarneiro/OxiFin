using AutoMapper;
using OxiFin.Domain;
using OxiFin.Domain.Entities;
using OxiFin.Domain.Entities.Auth;
using OxiFin.ViewModels;
using OxiFin.ViewModels.AppObject;
using OxiFin.ViewModels.AppObjects;

namespace OxiFin.Mapping.Profiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<EntityBase<long>, EntityBase_vw<long>>().ReverseMap();
            CreateMap<UserApp, UserApp_vw>().ReverseMap();
            CreateMap<UserApp, UserLogged>().ReverseMap();
            CreateMap<Debtor, Debtor_vw>().ReverseMap();
            CreateMap<Debit, Debit_vw>().ReverseMap();
            CreateMap<Payer, Payer_vw>().ReverseMap();
            CreateMap<BankAccount, BankAccount_vw>().ReverseMap();
            CreateMap<Bill, Bill_vw>().ReverseMap();
            CreateMap<Payment, Payment_vw>().ReverseMap();
        }
    }
}
