namespace demoBankApi.DTOs
{
    public class AccountResponse
    {
        public string Username { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Tel { get; set; } = string.Empty;
        public decimal Balance { get; set; } = 0;
        public List<TransactionResponse> Transactions { get; set; } = [];

        public AccountResponse() { }
        public AccountResponse(string username, string cpf, string tel, decimal balance, List<TransactionResponse> transactions)
        {
            Username = username;
            Cpf = cpf;
            Tel = tel;
            Balance = balance;
            Transactions = transactions;
        }
    }
}
