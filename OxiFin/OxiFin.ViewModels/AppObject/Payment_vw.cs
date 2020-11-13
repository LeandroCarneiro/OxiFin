using OxiFin.Common;
using System;

namespace OxiFin.ViewModels.AppObject
{
    public class Payment_vw : EntityBase_vw<long>
    {
        public long BillId { get; set; }
        public decimal Amount { get; set; }
        public ECurrency Currency { get; set; }
        public DateTime Date { get; set; }
        public long UserId { get; set; }
    }
}
