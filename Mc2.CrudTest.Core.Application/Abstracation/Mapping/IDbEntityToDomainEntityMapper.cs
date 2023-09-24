using Mc2.CrudTest.Core.Application.Models;
using Mc2.CrudTest.Core.Domain.Abstracation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Application.Abstracation.Mapping
{
    public interface IDbEntityToDomainEntityMapper<TDbEntity, TDomainEntity> where TDomainEntity : IDomainEntity where TDbEntity : IDbEntity
    {
        TDomainEntity Map(TDbEntity source);
    }
}
