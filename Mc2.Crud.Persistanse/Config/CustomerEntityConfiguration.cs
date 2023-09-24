using Mc2.CrudTest.Core.Application.Abstracation.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.Crud.Persistanse.Config
{
    internal class CustomerEntityConfiguration : IEntityTypeConfiguration<CustomerEntity>
    {
        public void Configure(EntityTypeBuilder<CustomerEntity> builder)
        {
            builder.Property(e => e.PhoneNumber).HasMaxLength(14);
            //other config
        }
    }
}
