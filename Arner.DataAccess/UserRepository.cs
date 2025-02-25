using Arner.DataAccess;
using Arner.DataAccess.Models;
using Arner.Service.IRepository;
using Microsoft.EntityFrameworkCore;
using Arner.Helper.Exceptions;

namespace Arner.Service
{
    public class UserRepository : IUserRepository
    {
        private readonly ArnerDbContext _context;
        public UserRepository(ArnerDbContext context)
        {
            _context = context;
        }

        public async Task<User> Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
            
        }

        public async Task<User> Delete(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserByName(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == name);
        }

        public async Task<User?> GetUserByID(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.ID == id);
        }

        public async Task<User> Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
        
        public async Task<IEnumerable<User>> GetAll() => await _context.Users.ToListAsync();
    }
}
