using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace AMS.API.Exstensions
{
    public static class HttpContentExt
    {
        public static async Task<T> GetFromBodyAsync<T>(this HttpContent content) where T : class
        {
            var json = await content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}