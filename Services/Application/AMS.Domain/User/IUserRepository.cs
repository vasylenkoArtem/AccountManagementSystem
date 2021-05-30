
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Domain 
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetAsync(int userId);

        Task<List<User>> GetUsersAsync();

        User AddUser(User user);

        Task<User> DeleteUser(int userId);


    }
}
