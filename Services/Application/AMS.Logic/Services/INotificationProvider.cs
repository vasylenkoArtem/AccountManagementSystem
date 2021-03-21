using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Logic.Services
{
    public interface INotificationProvider
    {
        void SendMessage(string text);

        void SendMessage(byte[] attachment);

        void SendMessage(string text, byte[] attachment);
    }
}
