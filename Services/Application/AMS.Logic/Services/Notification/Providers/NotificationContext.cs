using AMS.Database.MongoDb;
using AMS.Logic.Enums;
using AMS.Logic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Logic.Services
{
    public interface INotificationContext
    {
        NotificationProvider ResolveNotificationMessenger(int messengerTypeId);
    }

    public class NotificationContext : INotificationContext
    {
        private readonly IMongoDbConnector _mongoDbConnector;

        public NotificationContext(IMongoDbConnector mongoDbConnector)
        {
            _mongoDbConnector = mongoDbConnector;
        }
        
        public NotificationProvider ResolveNotificationMessenger(int messengerTypeId)
        {
            switch (messengerTypeId)
            {
                case ((int)MessengerType.Telegram):
                    return new TelegramNotificationProvider(_mongoDbConnector);
                case ((int)MessengerType.Viber):
                    return new ViberNotificationProvider(_mongoDbConnector);
                case ((int)MessengerType.Email):
                    return new EmailNotificationProvider(_mongoDbConnector);

                default:
                    return null;
            }
        }
    }
}
