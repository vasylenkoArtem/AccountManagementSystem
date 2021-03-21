using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Logic.Services
{
    public class EmailNotificationProvider : INotificationProvider
    {
        public void SendMessage(string text)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(byte[] attachment)
        {
            throw new NotImplementedException();
        }

        public void SendMessage(string text, byte[] attachment)
        {
            throw new NotImplementedException();
        }
    }
}
