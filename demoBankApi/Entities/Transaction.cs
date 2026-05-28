using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoBankApi.Entities
{
    [Table("transactions_tb")]
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public Account FromAccount { get; set; } = new Account();

        [Required]
        public Account ToAccount { get; set; } = new Account();

        [Required]
        public decimal Amount { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.Now;

        public Transaction() { }

        public Transaction(Account FromAccount, Account ToAccount, decimal Amount)
        {
            this.FromAccount = FromAccount;
            this.ToAccount = ToAccount;
            this.Amount = Amount;
        }
    }
}
