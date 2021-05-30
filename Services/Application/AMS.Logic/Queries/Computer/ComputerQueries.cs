using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AMS.Domain;
using AMS.Helpers;
using Dapper;

namespace SmartLab.Logic.Queries
{
    public interface IComputerQueries
    {
        Task<List<Computer>> GetComputers();
    }

    public class ComputerQueries : IComputerQueries
    {
        private readonly string _connectionString;

        public ComputerQueries(IConnectionStringProvider connectionString)
        {
            _connectionString = connectionString.ConnectionString;
        }

        public async Task<List<Computer>> GetComputers()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = (await connection.QueryAsync<Computer>(
                    @"
                    SELECT [Computer].[Id]
                        ,[Computer].[OperatingSystemId]
                        ,[Computer].[RoomId]
                    	,Room.Name as RoomName
                    	,Room.Number as RoomNumber
                    FROM [dbo].[Computer]
                    JOIN Room on [Computer].RoomId = Room.Id"
                )).ToList();

                result.ForEach(c => c.OperationSystem = GetOperationSystemName(c.OperatingSystemId));

                return result;
            }
        }

        private string GetOperationSystemName(int operationSystemId)
        {
            if (operationSystemId == 1)
            {
                return "Windows";
            }
            else if (operationSystemId == 2)
            {
                return "Linux";
            }
            else if (operationSystemId == 3)
            {
                return "MacOS";
            }

            return "";
        }
    }
}
