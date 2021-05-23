using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Database.MongoDb;
using AMS.Domain;
using AMS.Logic.Enums;
using AMS.Logic.Queries;
using TeleSharp.TL;
using TLSharp.Core;

namespace AMS.Logic.Services
{
    public interface IUserService
    {
        Task<User> AddNewUser(UserBuilderParams userBuilderParams);
    }

    public class UserService : IUserService
    {
        private readonly INotificationService _notificationService;
        private readonly IMongoDbConnector _mongoDbConnector;
        private readonly IUserRepository _userRepository;

        public UserService(INotificationService notificationService, IMongoDbConnector mongoDbConnector, IUserRepository userRepository)
        {
            _notificationService = notificationService;
            _mongoDbConnector = mongoDbConnector;
            _userRepository = userRepository;
        }

        public async Task<User> AddNewUser(UserBuilderParams userBuilderParams)
        {
            var userBuilder = new UserBuilder(userBuilderParams);
            var userBuilderDirector = new UserBuilderDirector
            {
                Builder = userBuilder
            };

            userBuilderDirector.BuildUser(userBuilderParams.UserTypeId);
            var user = userBuilder.GetResult();

            var savedUser = _userRepository.AddUser(user);
            await _userRepository.UnitOfWork.SaveEntitiesAsync();

            _notificationService.SendTextMessage((int)ActionType.ManageUsers, $"New User with Id {user.Id} added");

            return savedUser;
        }
    }
}
