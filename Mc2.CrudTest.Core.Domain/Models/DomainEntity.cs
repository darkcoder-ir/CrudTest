using Mc2.CrudTest.Core.Domain.Abstracation;
using Mc2.CrudTest.Core.Domain.Abstracation.Events;
using Mc2.CrudTest.Core.Domain.Abstracation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Domain.Models
{
    public abstract class DomainEntity : IDomainEntity
    {
        public int Id => throw new NotImplementedException();
        private static IDomainEventDispatcher dispatcher = new NullDomainEventDispatcher();
    }
}
