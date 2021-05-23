using AMS.Helpers;
using Dapper;
using SmartLab.Logic.Queries.Notification;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Logic.Queries
{
    public interface INotificationQueries
    {
        Task<IEnumerable<NotificationSubscription>> GetUserNotificationSubscriptions(int actionTypeId);
    }

    public class NotificationQueries : INotificationQueries
    {
        private readonly string _connectionString;

        public NotificationQueries(IConnectionStringProvider connectionString)
        {
            _connectionString = connectionString.ConnectionString;
        }

        public async Task<IEnumerable<NotificationSubscription>> GetUserNotificationSubscriptions(int actionTypeId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var result = await connection.QueryAsync<NotificationSubscription>(
                    @"

                     SELECT NotificationSubscription.UserMessengerId, 
                            NotificationSubscription.ActionTypeId, 
                            UserMessenger.UserIndetifier, 
                            UserMessenger.MessengerId

                     FROM NotificationSubscription
                     JOIN UserMessenger ON UserMessenger.Id = NotificationSubscription.UserMessengerId

                     WHERE NotificationSubscription.ActionTypeId = @actionTypeId

                    ", new { actionTypeId });

                return result;
            }
        }
    }
}
