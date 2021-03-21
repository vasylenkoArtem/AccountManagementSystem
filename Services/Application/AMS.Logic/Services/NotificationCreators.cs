using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Logic.Services
{
    /// <summary>
    /// TO DELETE, UNUSED PATTERN
    /// </summary>
    public abstract class NotificationCreator
    {
        public abstract INotificationProvider FactoryMethod();

        public void SendMessage(string text)
        {
            var notification = FactoryMethod();
            notification.SendMessage(text);
        }

        public void SendMessage(byte[] attachment)
        {
            var notification = FactoryMethod();
            notification.SendMessage(attachment);
        }

        public void SendMessage(string text, byte[] attachment)
        {
            var notification = FactoryMethod();
            notification.SendMessage(text, attachment);
        }

    }

    public class TelegramNotificationCreator : NotificationCreator
    {
        public override INotificationProvider FactoryMethod()
        {
            return new TelegramNotificationProvider();
        }
    }

    public class ViberNotificationCreator : NotificationCreator
    {
        public override INotificationProvider FactoryMethod()
        {
            return new ViberNotificationProvider();
        }
    }

    public class EmailNotificationCreator : NotificationCreator
    {
        public override INotificationProvider FactoryMethod()
        {
            return new EmailNotificationProvider();
        }
    }
}
