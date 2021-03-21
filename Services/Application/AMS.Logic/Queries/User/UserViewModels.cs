using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Logic.Queries
{
    public class UserBaseData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserTypeId { get; set; }
        public string RFIDKey { get; set; }
        public string IdentityLockUserId { get; set; }
        public string Email { get; set; }
    }

    public class UserData : UserBaseData
    {
        public UserData()
        {
        }

        public string RoomIdsString { get; set; }
        public string RoomNumbersString { get; set; }

        public List<int> RoomIds => RoomIdsString?.Split(',').Select(int.Parse).ToList() ?? new List<int>();
        public List<string>  RoomNumbers => RoomNumbersString?.Split(',').ToList() ?? new List<string>();

    }

}
