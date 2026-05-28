using demoBankApi.Data;
using demoBankApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace demoBankApi.Repositories
{
    public class AccountRepository
    {
        private readonly AppDbContext _context;

        public AccountRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Account> Save(Account entity)
        {
            if (entity.Id == 0)
            {
                _context.Accounts.Add(entity);
            }
            else
            {
                _context.Accounts.Update(entity);
            }
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Account?> FindById(long Id)
        {
            return await _context.Accounts.FindAsync(Id);
        }

        public async Task<List<Account>> FindAll()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<List<Account>> FindByUserId(long Id)
        {
            return await _context.Accounts.Where(a => a.User.Id == Id).ToListAsync();
        }

        public void DeleteById(long Id)
        {
            Account Placeholder = new()
            {
                Id = Id
            };

            _context.Accounts.Remove(Placeholder);
        }
    }
}
