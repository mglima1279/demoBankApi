using System.ComponentModel.DataAnnotations;

namespace demoBankApi.DTOs
{
    public class TransactionResponse
    {
        public string FromUsername { get; set; } = string.Empty;
        public string ToUsername { get; set; } = string.Empty;
        public decimal Amount { get; set; } = 0;

        [Required]
        public DateTime Timestamp { get; set; }

        public TransactionResponse(string fromUsername, string toUsername, decimal amount, DateTime timestamp)
        {
            FromUsername = fromUsername;
            ToUsername = toUsername;
            Amount = amount;
            Timestamp = timestamp;
        }

        public TransactionResponse() { }

    }
}
