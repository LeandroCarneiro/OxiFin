using OxiFin.Domain.Entities;
using OxiFin.ViewModels.AppObjects;

namespace OxiFin.Application.AppServices
{
    public class DebitAppService : BaseAppService<Debit_vw, Debit>
    {
        public DebitAppService(IBusiness<Debit> business) : base(business)
        {
        }
    }
}
