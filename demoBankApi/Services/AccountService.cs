using demoBankApi.DTOs;
using demoBankApi.Entities;
using demoBankApi.Mappers;
using demoBankApi.Repositories;

namespace demoBankApi.Services
{
    public class AccountService
    {
        private readonly AccountRepository _accountRepository;
        private readonly TransactionRepository _transactionRepository;

        public AccountService(AccountRepository accountRepository, TransactionRepository transactionRepository)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<Account> Create(User user, string cpf, string tel)
        {
            Account account = new()
            {
                User = user,
                Cpf = cpf,
                Tel = tel,
                Balance = 0
            };
            return await _accountRepository.Save(account);
        }

        public async Task<Account> Read(long UserId)
        {
            return await _accountRepository.FindByUserId(UserId)
                ?? throw new Exception("Account not found");
        }

        public async Task<AccountResponse> ReadDTO(long UserId)
        {
            Account account = await Read(UserId);

            AccountResponse dto = AccountMapper.fromEntity(account);

            dto.Transactions = (await _transactionRepository.FindByAccountId(account.Id))
                .Select(TransactionMapper.FromEntity)
                .ToList();

            return dto;
        }

        public async Task<Account> Deposit(long Id, decimal amount)
        {
            Account account = await Read(Id);
            account.Balance += amount;
            return account;
        }
        public async Task<Account> Withdraw(long Id, decimal amount)
        {
            Account account = await Read(Id);
            if(!HasBalance(account, amount))
            {
                throw new Exception("Insufficient balance");
            }

            account.Balance -= amount;

            return account;
        }
        private bool HasBalance(Account account, decimal Amount)
        {
            return account.Balance >= Amount;
        }

        //-----------------------------------------------------------------
        //transaction orientated programming

    }
}
