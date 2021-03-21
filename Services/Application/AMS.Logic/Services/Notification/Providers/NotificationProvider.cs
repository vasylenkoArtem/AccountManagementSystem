using AMS.Database.MongoDb;
using SmartLab.Logic.Queries.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Logic.Services
{
    public abstract class NotificationProvider
    {
        private readonly IMongoDbConnector _mongoDbConnector;

        public NotificationProvider(IMongoDbConnector mongoDbConnector)
        {
            _mongoDbConnector = mongoDbConnector;
        }

        public abstract void SendMessage(string text);

        public abstract void SendMessage(string attachmentName, byte[] attachment);

        public abstract void SendMessage(string text, string attachmentName, byte[] attachment);

        public void SaveMessage(string text = null, string attachmentName = null, byte[] attachment = null)
        {
            //save file to the server

            //save info to the mongodb
            var notification = new Notification
            {
                MessageText = text,
                AttachmentName = attachmentName
            };

            _mongoDbConnector.Add(new List<Notification> { notification });

        }
    }
}
