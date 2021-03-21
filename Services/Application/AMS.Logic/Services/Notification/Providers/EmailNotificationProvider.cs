using AMS.Database.MongoDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Logic.Services
{
    public class EmailNotificationProvider : NotificationProvider
    {
        public EmailNotificationProvider(IMongoDbConnector mongoDbConnector) : base(mongoDbConnector)
        { }

        public override void SendMessage(string text)
        {
            throw new NotImplementedException();
        }

        public override void SendMessage(string attachmentName, byte[] attachment)
        {
            throw new NotImplementedException();
        }

        public override void SendMessage(string text, string attachmentName, byte[] attachment)
        {
            throw new NotImplementedException();
        }
    }
}
