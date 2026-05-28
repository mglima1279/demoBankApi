using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoBankApi.Entities
{
    [Table("accounts_tb")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public User User { get; set; } = new User();

        [Required]
        [StringLength(11)]
        public string Cpf {  get; set; } = string.Empty;

        [Required]
        [StringLength(11)]
        public string Tel { get; set; } = string.Empty;

        [Required]
        public decimal Balance { get; set; } = decimal.Zero;

        public Account() { }
        public Account(User user, string Cpf, string Tel)
        {
            this.User = user;
            this.Cpf = Cpf;
            this.Tel = Tel;
        }
    }
}
