using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartLab.API.Modules.Confuguration
{
    public interface IConnectionStringProvider
    {
        string ConnectionString { get; }
    }

    public class ConnectionStringProvider : IConnectionStringProvider
    {
        public ConnectionStringProvider(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; }
    }
}