using SmartLab.Logic.Queries.UserRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLab.Logic.Services.UserRoom
{
    public interface IUserRoomService
    {
        Task<bool> UnlockRoom(string roomNumber);
    }

    public class UserRoomService : IUserRoomService
    {
        private readonly IUserRoomQueries _userRoomQueries;

        public UserRoomService(IUserRoomQueries userRoomQueries)
        {
            _userRoomQueries = userRoomQueries;
        }

        public async Task<bool> UnlockRoom(string roomNumber)
        {
            //TODO: Change when identity will be confidured
            var rfidCardId = "gfjk45423ff"; //_userProvider.GetUserId..

            var userId = await _userRoomQueries.GetUserIdByRFIDCard(rfidCardId);

            if(!userId.HasValue)
            {
                throw new Exception("Unknown RFID card");
            }

            var isAllowToUnlock = await _userRoomQueries.CheckUserForAccess(roomNumber, userId.Value);

            return isAllowToUnlock;
        }
    }
}
