using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Application.Abstracation.Mapping
{
   public interface IDbEntityToValueObjectMapper<TDbEntity, TValueObject> where TValueObject : IValueObject where TDbEntity : IDbEntity
    {
        TValueObject Map(TDbEntity source);
    }
}
