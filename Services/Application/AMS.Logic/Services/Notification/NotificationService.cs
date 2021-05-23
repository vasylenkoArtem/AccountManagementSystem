using AMS.Logic.Enums;
using AMS.Logic.Queries;
using SmartLab.Logic.Queries.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Logic.Services
{
    public interface INotificationService
    {
        Task SendTextMessage(int actionTypeId, string text);

        Task SendMessageWithAttachment(int actionTypeId, string attachmentName, byte[] attachment);

        Task SendMessageWithTextAndAttachment(int actionTypeId, string text, string attachmentName, byte[] attachment);
    }

    public class NotificationService : INotificationService
    {
        private readonly INotificationContext _notificationContext;
        private readonly INotificationQueries _notificationQueries;

        public NotificationService(INotificationContext notificationContext, INotificationQueries notificationQueries)
        {
            _notificationContext = notificationContext;
            _notificationQueries = notificationQueries;
        }

        public async Task SendTextMessage(int actionTypeId, string text)
        {
            var subscriptions = await _notificationQueries.GetUserNotificationSubscriptions(actionTypeId);

            // Notify all subscribed members about the action
            foreach (var subscription in subscriptions)
            {
                var notificationProvider = _notificationContext.ResolveNotificationMessenger(subscription.MessengerTypeId);

                notificationProvider.SendMessage(subscription.UserIndetifier, text);
                notificationProvider.SaveMessage(subscription.UserIndetifier, text: text);
            }
        }

        public async Task SendMessageWithAttachment(int actionTypeId, string attachmentName, byte[] attachment)
        {
            var subscriptions = await _notificationQueries.GetUserNotificationSubscriptions(actionTypeId);

            // Notify all subscribed members about the action
            foreach (var subscription in subscriptions)
            {
                var notificationProvider = _notificationContext.ResolveNotificationMessenger(subscription.MessengerTypeId);

                notificationProvider.SendMessage(subscription.UserIndetifier, attachmentName, attachment);
                notificationProvider.SaveMessage(subscription.UserIndetifier, attachment: attachment, attachmentName: attachmentName);
            }
        }

        public async Task SendMessageWithTextAndAttachment(int actionTypeId, string text, string attachmentName, byte[] attachment)
        {
            var subscriptions = await _notificationQueries.GetUserNotificationSubscriptions(actionTypeId);

            // Notify all subscribed members about the action
            foreach (var subscription in subscriptions)
            {
                var notificationProvider = _notificationContext.ResolveNotificationMessenger(subscription.MessengerTypeId);

                notificationProvider.SendMessage(subscription.UserIndetifier, attachmentName, attachment);
                notificationProvider.SaveMessage(subscription.UserIndetifier, attachment: attachment, attachmentName: attachmentName, text: text);
            }
        }
    }
}
