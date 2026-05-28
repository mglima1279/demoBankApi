using demoBankApi.DTOs;
using demoBankApi.Entities;

namespace demoBankApi.Mappers
{
    public class TransactionMapper
    {
        public static TransactionResponse FromEntity(Transaction entity)
        {
            return new TransactionResponse
            {
                Id = entity.Id,
                ToUsername = entity.ToAccount.User.Username,
                FromUsername = entity.FromAccount.User.Username,
                Amount = entity.Amount,
                Timestamp = entity.Timestamp,
            };
        }

        public static Transaction ToEntity(TransactionRequest request)
        {
            return new Transaction
            {
                Amount = request.Amount,
                Timestamp = DateTime.UtcNow
            };
        }
    }
}
