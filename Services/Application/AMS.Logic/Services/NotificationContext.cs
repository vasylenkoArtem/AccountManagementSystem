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
        INotificationProvider ResolveNotificationMessenger(int messengerTypeId);
    }

    public class NotificationContext : INotificationContext
    {

        public INotificationProvider ResolveNotificationMessenger(int messengerTypeId)
        {
            switch (messengerTypeId)
            {
                case ((int)MessengerType.Telegram):
                    return new TelegramNotificationProvider();
                case ((int)MessengerType.Viber):
                    return new ViberNotificationProvider();
                case ((int)MessengerType.Email):
                    return new EmailNotificationProvider();

                default:
                    return null;
            }
        }
    }
}
