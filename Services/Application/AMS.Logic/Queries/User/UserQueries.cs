using AMS.Helpers;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Logic.Queries
{
    public interface IUserQueries
    {
        Task<IEnumerable<UserData>> GetUsers();
    }

    public class UserQueries : IUserQueries
    {
        private readonly string _connectionString;

        public UserQueries(IConnectionStringProvider connectionString)
        {
            _connectionString = connectionString.ConnectionString;
        }

        public async Task<IEnumerable<UserData>> GetUsers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<UserData>(
                    @"
                    SELECT [User].[Id]
                         ,[User].[FirstName]
                         ,[User].[LastName]
                         ,[User].[Email]
                         ,[User].[UserTypeId]
                         ,[User].[IdentityLockUserId]
                    	  ,STRING_AGG(UserRoom.RoomId, ', ') AS RoomIdsString
                    	  ,STRING_AGG(Room.Number, ', ') RoomNumbersString

                    FROM [dbo].[User]
                    JOIN UserRoom ON UserRoom.UserId = [User].Id 
                    JOIN Room ON Room.Id = UserRoom.RoomId

                    WHERE UserRoom.IsAvaliable = 1

                    GROUP BY [User].[Id]
                        ,[User].[FirstName]
                        ,[User].[LastName]
                        ,[User].[Email]
                        ,[User].[UserTypeId]
                        ,[User].[IdentityLockUserId]");

                return result;
            }
        }
    }
}
