using AMS.Domain;
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
        private readonly AccountManagementSystemContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public UserRepository(AccountManagementSystemContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User> GetAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public User AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
