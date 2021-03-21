using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Logic.Services
{
    public interface INotificationService
    {
        void SendTextMessage(int messengerTypeId, string text);

        void SendMessageWithAttachment(int messengerTypeId, byte[] attachment);

        void SendMessageWithTextAndAttachment(int messengerTypeId, string text, byte[] attachment);
    }

    public class NotificationService : INotificationService
    {
        private readonly INotificationContext _notificationContext;

        public NotificationService(INotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public void SendTextMessage(int messengerTypeId, string text)
        {
            var notificationProvider = _notificationContext.ResolveNotificationMessenger(messengerTypeId);
            notificationProvider.SendMessage(text);
        }

        public void SendMessageWithAttachment(int messengerTypeId, byte[] attachment)
        {
            var notificationProvider = _notificationContext.ResolveNotificationMessenger(messengerTypeId);
            notificationProvider.SendMessage(attachment);
        }

        public void SendMessageWithTextAndAttachment(int messengerTypeId, string text, byte[] attachment)
        {
            var notificationProvider = _notificationContext.ResolveNotificationMessenger(messengerTypeId);
            notificationProvider.SendMessage(text, attachment);
        }
    }
}
