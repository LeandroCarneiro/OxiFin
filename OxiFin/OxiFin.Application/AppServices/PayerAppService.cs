using OxiFin.Domain.Entities;
using OxiFin.ViewModels.AppObject;

namespace OxiFin.Application.AppServices
{
    public class PayerAppService : BaseAppService<Payer_vw, Payer>
    {
        public PayerAppService(IBusiness<Payer> business) : base(business)
        {
        }
    }
}
