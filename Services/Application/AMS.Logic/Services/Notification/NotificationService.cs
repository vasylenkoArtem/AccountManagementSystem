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

        void SendMessageWithAttachment(int messengerTypeId, string attachmentName, byte[] attachment);

        void SendMessageWithTextAndAttachment(int messengerTypeId, string text, string attachmentName, byte[] attachment);
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
            notificationProvider.SaveMessage(text: text);
        }

        public void SendMessageWithAttachment(int messengerTypeId, string attachmentName, byte[] attachment)
        {
            var notificationProvider = _notificationContext.ResolveNotificationMessenger(messengerTypeId);
            notificationProvider.SendMessage(attachmentName, attachment);
            notificationProvider.SaveMessage(attachment: attachment, attachmentName : attachmentName);
        }

        public void SendMessageWithTextAndAttachment(int messengerTypeId, string text, string attachmentName, byte[] attachment)
        {
            var notificationProvider = _notificationContext.ResolveNotificationMessenger(messengerTypeId);
            notificationProvider.SendMessage(text, attachmentName, attachment);
            notificationProvider.SaveMessage(text, attachmentName, attachment);
        }
    }
}
