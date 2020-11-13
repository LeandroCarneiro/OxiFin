using OxiFin.Domain.Entities;
using OxiFin.ViewModels.AppObjects;

namespace OxiFin.Application.AppServices
{
    public class DebtorAppService : BaseAppService<Debtor_vw, Debtor>
    {
        public DebtorAppService(IBusiness<Debtor> business) : base(business)
        {
        }
    }
}
