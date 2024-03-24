using Mc2.CrudTest.Core.Application.Abstracation.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Mc2.Crud.Persistanse.DbContexts
{
    public class ApplicationWriteDbContext : DbContext, IApplicationWriteDbContext // this is just for write to db and for reading that i will using dapper
    {
        public IDbConnection Connection
        {
            get
            {
                DbConnection _db =Database.GetDbConnection();
                if (_db.State!= ConnectionState.Open)
                    _db.Open();
                return _db;
            }
        }

        public DbSet<CustomerEntity> Customers  { get; set; } = default!;


        public ApplicationWriteDbContext(DbContextOptions<ApplicationWriteDbContext> options)
                                            : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationWriteDbContext).Assembly);


        //we can also ovverrride savechangeasync method to set default value for auditable entities
    }
}
