using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Core.Application.Abstracation.NewRepositoryPattern;
using Mc2.CrudTest.Core.Domain.Abstracation.Models;

namespace Mc2.Crud.Persistanse.DbContext
{
    public class IwriteRepository<T> : IWriteRepository<T> where T : class , IAggregateRoot
    {
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
