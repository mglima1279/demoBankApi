using demoBankApi.Data;
using demoBankApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace demoBankApi.Repositories
{
    public class TransactionRepository
    {
        private readonly AppDbContext _context;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<Transaction> Save(Transaction entity)
        {
            if (entity.Id == 0)
            {
                _context.Transactions.Add(entity);
            }
            else
            {
                _context.Transactions.Update(entity);
            }
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Transaction?> FindById(long Id)
        {
            return await _context.Transactions.FindAsync(Id);
        }

        public async Task<List<Transaction>> FindAll()
        {
            return await _context.Transactions.ToListAsync();
        }

        public async Task<List<Transaction>> FindByToAccountId(long accountId)
        {
            return await _context.Transactions.Where(t=>t.ToAccount.Id == accountId).ToListAsync();
        }
        
        public async Task<List<Transaction>> FindByFromAccountId(long accountId)
        {
            return await _context.Transactions.Where(t=>t.FromAccount.Id == accountId).ToListAsync();
        }

        public async Task Delete(long id)
        {
            Transaction Placeholder = new()
            {
                Id = id
            };

            _context.Transactions.Remove(Placeholder);
        }
    }
}
