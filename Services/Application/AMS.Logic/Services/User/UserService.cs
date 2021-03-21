using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Domain.User;

namespace AMS.Logic.Services
{
    public interface IUserService
    {
        User AddNewUser(UserBuilderParams userBuilderParams);
    }

    public class UserService : IUserService
    {
        public User AddNewUser(UserBuilderParams userBuilderParams)
        {
            var userBuilder = new UserBuilder(userBuilderParams);
            var userBuilderDirector = new UserBuilderDirector
            {
                Builder = userBuilder
            };

            userBuilderDirector.BuildUser(userBuilderParams.UserTypeId);
            var user = userBuilder.GetResult();

            return user;
        }
    }
}
