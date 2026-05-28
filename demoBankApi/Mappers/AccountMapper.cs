using demoBankApi.DTOs;
using demoBankApi.Entities;

namespace demoBankApi.Mappers
{
    public class AccountMapper
    {
        public static AccountResponse fromEntity(Account entity)
        {
            return new AccountResponse
            {
                Cpf = entity.Cpf,
                Tel = entity.Tel,
                Balance = entity.Balance
            };
        }
    }
}
