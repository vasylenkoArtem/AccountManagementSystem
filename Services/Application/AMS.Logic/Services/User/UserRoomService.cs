﻿using AMS.Logic.Queries.UserRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Logic.Services
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
            //TODO: Change hardcode rfid key when identity will be confidured
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
