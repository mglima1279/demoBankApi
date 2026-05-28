using System.ComponentModel.DataAnnotations;

namespace demoBankApi.DTOs
{
    public class TransactionResponse
    {
        public long Id { get; set; }
        public string FromUsername { get; set; } = string.Empty;
        public string ToUsername { get; set; } = string.Empty;
        public decimal Amount { get; set; } = 0;

        [Required]
        public DateTime Timestamp { get; set; }

        public TransactionResponse(long Id, string fromUsername, string toUsername, decimal amount, DateTime timestamp)
        {
            this.Id = Id;
            this.FromUsername = fromUsername;
            this.ToUsername = toUsername;
            this.Amount = amount;
            this.Timestamp = timestamp;
        }

        public TransactionResponse() { }

    }
}
