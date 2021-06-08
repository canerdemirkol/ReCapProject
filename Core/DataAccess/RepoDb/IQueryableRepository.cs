using Core.Entities;
using System.Collections.Generic;

namespace Core.DataAccess.RepoDb
{
    public interface IQueryableRepository<T> where T : class, IDto, new()
    {
        IEnumerable<T> GetByExecuteTextQuery(string commandText, object param = null);

        IEnumerable<T> GetByExecuteStoredProcedureQuery(string commandText, object param = null);
        T GetByExecuteStoredProcedureSingle(string commandText, object param = null);
    }
}
