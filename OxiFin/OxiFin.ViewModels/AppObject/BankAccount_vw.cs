namespace OxiFin.ViewModels.AppObject
{
    public class BankAccount_vw : EntityBase_vw<long>
    {
        public string BankName { get; set; }
        public string Account { get; set; }
        public int Agency { get; set; }
        public bool Active { get; set; }

        public long UserId { get; set; }
    }
}
