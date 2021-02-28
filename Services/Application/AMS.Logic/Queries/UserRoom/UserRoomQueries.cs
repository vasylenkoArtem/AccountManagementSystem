using AMS.Helpers;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartLab.Logic.Queries.UserRoom
{
    public interface IUserRoomQueries
    {
        Task<bool> CheckUserForAccess(string roomNumber, int userId);

        Task<int?> GetUserIdByRFIDCard(string rfidCardId);
    }

    public class UserRoomQueries : IUserRoomQueries
    {
        private readonly string _connectionString;
        public UserRoomQueries(IConnectionStringProvider connectionString)
        {
            _connectionString = connectionString.ConnectionString;
        }

        public async Task<bool> CheckUserForAccess(string roomNumber, int userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryFirstOrDefaultAsync<object>(
                    @"
                    SELECT UserRoom.IsAvaliable 
                    FROM UserRoom
                    JOIN Room ON Room.Id = UserRoom.RoomId
                    WHERE Room.Number = @roomNumber
                        AND UserId = @userId
                        AND IsAvaliable = 1"
                , new { roomNumber, userId });

                return result != null;
            }
        }

        public async Task<int?> GetUserIdByRFIDCard(string rfidCardId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryFirstOrDefaultAsync<int?>(
                    @"
                    SELECT [User].Id 
	                FROM [User]
	                WHERE [User].IdentityLockUserId = @rfidCardId "
                , new { rfidCardId });

                return result;
            }
        }
    }
}
