namespace OxiFin.ViewModels.AppObject
{
    public class Payer_vw : EntityBase_vw<long>
    {
        public string Name { get; set; }
        public decimal Incomes { get; set; }
        public long UserId { get; set; }
    }
}
