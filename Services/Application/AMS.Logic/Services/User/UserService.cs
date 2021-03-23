using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Domain.User;
using AMS.Logic.Enums;

namespace AMS.Logic.Services
{
    public interface IUserService
    {
        User AddNewUser(UserBuilderParams userBuilderParams);
    }

    public class UserService : IUserService
    {
        private readonly INotificationService _notificationService;
        
        public UserService(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public User AddNewUser(UserBuilderParams userBuilderParams)
        {
            

            var userBuilder = new UserBuilder(userBuilderParams);
            var userBuilderDirector = new UserBuilderDirector();
            userBuilderDirector.Builder = userBuilder;

            userBuilderDirector.BuildUser(userBuilderParams.UserTypeId);

            var user = userBuilder.GetResult();

            //_save changes with repository 

            //get subscribed users and messengers
            var subscribedUserId = 2;
            var messengerId = (int)MessengerType.Telegram;

            _notificationService.SendTextMessage(subscribedUserId, messengerId, $"New User with Id {user.Id} added");

            return user;
        }
    }
}
