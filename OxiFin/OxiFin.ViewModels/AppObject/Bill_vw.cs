using OxiFin.Common;

namespace OxiFin.ViewModels.AppObject
{
    public class Bill_vw : EntityBase_vw<long>
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public ECurrency Currency { get; set; }
        public long DebtorId { get; set; }
    }
}
