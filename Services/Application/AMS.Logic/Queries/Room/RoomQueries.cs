using AMS.Domain;
using AMS.Helpers;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Logic.Queries.UserRoom
{
    public interface IRoomQueries
    {
        Task<List<Room>> GetRooms();
    }

    public class RoomQueries : IRoomQueries
    {
        private readonly string _connectionString;

        public RoomQueries(IConnectionStringProvider connectionString)
        {
            _connectionString = connectionString.ConnectionString;
        }

        public async Task<List<Room>> GetRooms()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<Room>(
                    @"
                    SELECT DISTINCT [Id]
                         ,[Number]
                         ,[Name]
                     FROM [dbo].[Room]"
                );

                return result.ToList();
            }
        }
    }
}
