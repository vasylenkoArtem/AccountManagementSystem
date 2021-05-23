using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLab.Domain.Notification
{
    public class NotificationSubscription
    {
        [Key]
        public int Id { get; private set; }

        public int UserMessengerId { get; private set; }

        public int ActionTypeId { get; private set; }

        public virtual UserMessenger UserMessenger { get; set; }

    }
}
