using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLab.Logic.Queries.Notification
{
    public class Notification
    {
        public int Id { get; set; }
        public string MessageText { get; set; }
        public string AttachmentPath { get; set; }
        public string AttachmentName { get; set; }
    }
}
