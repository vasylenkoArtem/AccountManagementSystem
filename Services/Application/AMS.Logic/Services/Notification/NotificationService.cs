using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Logic.Services
{
    public interface INotificationService
    {
        void SendTextMessage(int userId, int messengerTypeId, string text);

        void SendMessageWithAttachment(int userId, int messengerTypeId, string attachmentName, byte[] attachment);

        void SendMessageWithTextAndAttachment(int userId, int messengerTypeId, string text, string attachmentName, byte[] attachment);
    }

    public class NotificationService : INotificationService
    {
        private readonly INotificationContext _notificationContext;

        public NotificationService(INotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public void SendTextMessage(int userId, int messengerTypeId, string text)
        {
            var notificationProvider = _notificationContext.ResolveNotificationMessenger(messengerTypeId);
            
            notificationProvider.SendMessage(userId, text);
            notificationProvider.SaveMessage(userId, text: text);
        }

        public void SendMessageWithAttachment(int userId, int messengerTypeId, string attachmentName, byte[] attachment)
        {
            var notificationProvider = _notificationContext.ResolveNotificationMessenger(messengerTypeId);
            notificationProvider.SendMessage(userId, attachmentName, attachment);
            notificationProvider.SaveMessage(userId, attachment: attachment, attachmentName : attachmentName);
        }

        public void SendMessageWithTextAndAttachment(int userId, int messengerTypeId, string text, string attachmentName, byte[] attachment)
        {
            var notificationProvider = _notificationContext.ResolveNotificationMessenger(messengerTypeId);
            notificationProvider.SendMessage(userId, text, attachmentName, attachment);
            notificationProvider.SaveMessage(userId, text, attachmentName, attachment);
        }
    }
}
