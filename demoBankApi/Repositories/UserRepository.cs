using demoBankApi.Data;
using demoBankApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace demoBankApi.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> Save(User entity)
        {
            if (entity.Id == 0)
            {
                _context.Users.Add(entity);
            }
            else
            {
                _context.Users.Update(entity);
            }
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<User?> FindById(long Id)
        {
            return await _context.Users.FindAsync(Id);
        }

        public async Task<List<User>> FindAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<List<User>> FindByUsername(string Username)
        {
            return await _context.Users.Where(u=>u.Username == Username).ToListAsync();
        }

        public void DeleteById(long Id)
        {
            User Placeholder = new()
            {
                Id = Id
            };

            _context.Users.Remove(Placeholder);
        }
    }
}
