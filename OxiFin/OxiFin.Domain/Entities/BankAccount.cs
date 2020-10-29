using System.ComponentModel.DataAnnotations.Schema;

namespace OxiFin.Domain.Entities
{
    [Table("tblBankAccounts")]
    public class BankAccount : EntityBase<long>
    {
        public string BankName { get; set; }
        public string Account { get; set; }
        public int Agency { get; set; }        
    }
}
