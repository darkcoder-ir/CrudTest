using Dapper;
using Mc2.CrudTest.Core.Application.Abstracation.DbContext;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Core.Application.Abstracation.NewRepositoryPattern;

namespace Mc2.Crud.Persistanse.DbContexts
{
    //public class ApplicationReadDbFacade<T> : IReadRepository<T>, IDisposable
    //{
    //    private readonly IDbConnection connection;

    //    private bool disposedValue = false;

    //    public ApplicationReadDbFacade(IConfiguration configuration) => connection = new SqlConnection(configuration.GetConnectionString("ApplicationReadDatabase"));

    //    public void Dispose()
    //    {
    //        Dispose(disposing: true);
    //        GC.SuppressFinalize(this);
    //    }

    //    public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
    //                        => (await connection.QueryAsync<T>(sql, param, transaction)).AsList();

    //    public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
    //        => await connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);

    //    public async Task<T> QuerySingleAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
    //        => await connection.QuerySingleAsync<T>(sql, param, transaction);

    //    protected virtual void Dispose(bool disposing)
    //    {
    //        if (!disposedValue)   // best practise diposing managed and unmanaged objects
    //        {
    //            if (disposing)
    //            {
                  
    //                connection.Dispose();
    //            }

    //            disposedValue = true;
    //        }
    //    }
    //}
}
