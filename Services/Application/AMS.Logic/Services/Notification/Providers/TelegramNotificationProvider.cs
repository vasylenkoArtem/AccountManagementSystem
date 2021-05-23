using AMS.Database.MongoDb;
using SmartLab.Logic.Services.Notification.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeleSharp.TL;
using TLSharp.Core;

namespace AMS.Logic.Services
{
    public class TelegramNotificationProvider : NotificationProvider
    {
        private readonly ITelegramConnectionStringProvider _telegramConnectionStringProvider;

        public TelegramNotificationProvider(IMongoDbConnector mongoDbConnector, ITelegramConnectionStringProvider telegramConnectionStringProvider) : base(mongoDbConnector)
        {
            _telegramConnectionStringProvider = telegramConnectionStringProvider;
        }

        public async override void SendMessage(string userId, string text)
        {
            var client = new TelegramClient(_telegramConnectionStringProvider.ApiId, _telegramConnectionStringProvider.ApiHash);
            await client.ConnectAsync();

            //send message
            await client.SendMessageAsync(new TLInputPeerUser() { UserId = int.Parse(userId) }, text);
        }

        public override void SendMessage(string userId, string attachmentName, byte[] attachment)
        {
            throw new NotImplementedException();
        }

        public override void SendMessage(string userId, string text, string attachmentName, byte[] attachment)
        {
            throw new NotImplementedException();
        }

        //TODO: Create console app, add to the TG contacts needed persons 
        // and export users data to use in the AMS

        // Code to retrieve once auth
        //var hash = await client.SendCodeRequestAsync("+380953808738");
        //var code = "<code_from_telegram>"; // you can change code in debugger

        //var user = await client.MakeAuthAsync("+380953808738", hash, code);

        //get available contacts
        //var result = await client.GetContactsAsync();

        //var user2 = result.Users
        //    .OfType<TLUser>()
        //    .FirstOrDefault();
    }
}
