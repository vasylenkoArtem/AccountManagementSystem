using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Domain.Notification
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }

        public string MessageText { get; set; }

        public string AttachmentPath { get; set; }

        public string AttachmentName { get; set; }
    }
}
