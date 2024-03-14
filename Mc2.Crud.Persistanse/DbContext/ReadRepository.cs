using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Core.Application.Abstracation.NewRepositoryPattern;

namespace Mc2.Crud.Persistanse.DbContext
{
    public class ReadRepository<T> : IReadRepository<T> where T : class
    {
        public Task<IReadOnlyList<T1>> QueryAsync<T1>(string sql, object? param = null, IDbTransaction? transaction = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<T1> QueryFirstOrDefaultAsync<T1>(string sql, object? param = null, IDbTransaction? transaction = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<T1> QuerySingleAsync<T1>(string sql, object? param = null, IDbTransaction? transaction = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
