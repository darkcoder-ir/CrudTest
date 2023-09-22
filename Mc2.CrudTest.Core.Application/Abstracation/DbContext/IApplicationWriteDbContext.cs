using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Application.Abstracation.DbContext
{
    public interface IApplicationWriteDbContext
    {
        IDbConnection Connection { get; }
        DbSet<CustomerEntity> Customers { get; }
        DatabaseFacade Database { get; }
    }
}
