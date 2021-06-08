using Core.DataAccess.RepoDb.DbConnectionOptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess.Concrete.RepoDb.DbConnection.SqlDatabases
{
    public class ReCapDbConnectionFactory : IDatabaseConnectionFactory
    {
        private readonly string _connectionStringValue;

        public ReCapDbConnectionFactory()
        {
            _connectionStringValue = new AppConfiguration(
                                                           DatabaseConnectionName.RecapMsContext
                                                         )._connectionString;
        }

        public string ConnectionString
        {
            get { return _connectionStringValue; }
            set { ConnectionString = _connectionStringValue; }
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionStringValue);
        }

        public void Dispose()
        {
            Dispose();
        }
    }
}
