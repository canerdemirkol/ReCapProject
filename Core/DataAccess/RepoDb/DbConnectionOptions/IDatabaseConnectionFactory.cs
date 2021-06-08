using System;
using System.Data;

namespace Core.DataAccess.RepoDb.DbConnectionOptions
{
    public interface IDatabaseConnectionFactory : IDisposable
    {
        IDbConnection CreateConnection();

       
    }
}