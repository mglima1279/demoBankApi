namespace demoBankApi.DTOs
{
    public class TransactionRequest
    {
        public long ToAccountId { get; set; } = 0;
        public decimal Amount { get; set; } = 0;

        public TransactionRequest() { }

        public TransactionRequest(long toAccountId, decimal amount)
        {
            ToAccountId = toAccountId;
            Amount = amount;
        }
    }
}
