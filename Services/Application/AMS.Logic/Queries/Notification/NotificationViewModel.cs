using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLab.Logic.Queries.Notification
{
    public class Notification
    {
        public string MessageText { get; set; }
        public string AttachmentPath { get; set; }
        public string AttachmentName { get; set; }
        public string UserId { get; set; }
    }

    public class NotificationSubscription
    {
        public int Id { get; set; }

        public int UserMessengerId { get; set; }

        public int ActionTypeId { get; set; }

        public string UserIndetifier { get; set; }

        public int MessengerTypeId { get; set; }

        //Viber
    }
}
