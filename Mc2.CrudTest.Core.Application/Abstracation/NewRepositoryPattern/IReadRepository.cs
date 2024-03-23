using System.Data;
using Ardalis.Specification;
using Mc2.CrudTest.Core.Domain.Abstracation.Models;
using Mc2.CrudTest.Core.Domain.Models;

namespace Mc2.CrudTest.Core.Application.Abstracation.NewRepositoryPattern;

public interface IReadRepository<T> where T : class//                : IReadRepositoryBase<T> where T : class
{

    Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null,
        CancellationToken cancellationToken = default);

    Task<T> QueryFirstOrDefaultAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null,
        CancellationToken cancellationToken = default);

    Task<T> QuerySingleAsync<T>(string sql, object? param = null, IDbTransaction? transaction = null,
        CancellationToken cancellationToken = default);

}