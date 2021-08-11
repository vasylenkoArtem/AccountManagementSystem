using AMS.Domain;
using SmartLab.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IAccountManagementSystemContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public UserRepository(IAccountManagementSystemContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> GetAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<User> DeleteUser(int userId)
        {
            var user = await GetAsync(userId);

            return _context.Users.Remove(user);
        }

        public User AddUser(User user)
        {
            return _context.Users.Add(user);
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
