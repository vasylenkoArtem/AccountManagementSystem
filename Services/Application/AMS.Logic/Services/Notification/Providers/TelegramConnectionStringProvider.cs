using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLab.Logic.Services.Notification.Providers
{
    public interface ITelegramConnectionStringProvider
    {
        int ApiId { get; }
        string ApiHash { get; }
    }

    public class TelegramConnectionStringProvider : ITelegramConnectionStringProvider
    {
        public int ApiId { get; private set; }
        public string ApiHash { get; private set; }

        public TelegramConnectionStringProvider(int apiId, string apiHash)
        {
            ApiId = apiId;
            ApiHash = apiHash;
        }

    }
}
