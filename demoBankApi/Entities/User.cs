using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace demoBankApi.Entities
{
    [Table(name:"users_tb")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public User() { }
        public User(string Username, string Password)
        { 
            this.Username = Username;
            this.Password = Password;
        }
    }
}
