using OxiFin.Domain.Entities;
using OxiFin.ViewModels.AppObject;

namespace OxiFin.Application.AppServices
{
    public class BankAccountAppService : BaseAppService<BankAccount_vw, BankAccount>
    {
        public BankAccountAppService(IBusiness<BankAccount> business) : base(business)
        {
        }
    }
}
