namespace OxiFin.ViewModels.AppObjects
{
    public class Debit_vw : EntityBase_vw<long>
    {
        public string Description { get; set; }
        public long DebtorId { get; set; }
        public long PayerId { get; set; }
        public decimal Total { get; set; }
    }
}