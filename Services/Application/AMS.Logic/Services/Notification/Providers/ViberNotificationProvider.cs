using AMS.Database.MongoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Logic.Services
{
    public class ViberNotificationProvider : NotificationProvider
    {
        public ViberNotificationProvider(IMongoDbConnector mongoDbConnector) : base(mongoDbConnector)
        { }

        public override void SendMessage(string userId, string text)
        {
            throw new NotImplementedException();
        }

        public override void SendMessage(string userId, string attachmentName, byte[] attachment)
        {
            throw new NotImplementedException();
        }

        public override void SendMessage(string userId, string text, string attachmentName, byte[] attachment)
        {
            throw new NotImplementedException();
        }
    }
}
