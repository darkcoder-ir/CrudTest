using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;

using Mc2.CrudTest.Core.Application.Abstracation.NewRepositoryPattern;
using Mc2.CrudTest.Core.Domain.Entities;

using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Mc2.Crud.Persistanse.DbContext
{
    public class ReadRepository<T> : IDisposable, IReadRepository<T> where T : class
    {
        public ReadRepository(IDbContext DbContext)
        {
            dbContext = DbContext;
        }

        private readonly IDbContext dbContext;


        public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
            => (await dbContext.datbase.GetDbConnection().QueryAsync<T>(sql, param, transaction)).AsList();

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object? param = null,
            IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
        {
            var test = await dbContext.datbase.GetDbConnection().QueryFirstOrDefaultAsync<T>(sql, param, transaction);
            return test;
        }

        public async Task<T> QuerySingleAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
            => await dbContext.datbase.GetDbConnection().QuerySingleAsync<T>(sql, param, transaction);
        private bool disposedValue;
        protected virtual void Dispose(bool disposing)
        {

            if (!disposedValue)   // best practise diposing managed and unmanaged objects
            {
                if (disposing)
                {

                    dbContext.datbase.GetDbConnection().Dispose();
                }

                disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

