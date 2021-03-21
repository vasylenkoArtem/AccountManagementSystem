using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Logic.Services
{
    public class NotificationService
    {
        private readonly INotificationContext _notificationContext;

        public NotificationService(INotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public void SendMessage(int messengerTypeId, string message)
        {
            var notificationProvider = _notificationContext.ResolveNotificationMessenger(messengerTypeId);
            notificationProvider.SendMessage(message);
        }
    }
}
