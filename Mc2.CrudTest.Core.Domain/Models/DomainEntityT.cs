using Mc2.CrudTest.Core.Domain.Abstracation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Domain.Models
{
    public abstract class DomainEntity<TEntity> : DomainEntity where TEntity : IDomainEntity
    {
        public TEntity CloneWith(Action<TEntity> action)
        {
            var e = CreateShallowCopy();
            action(e);
            return e;
        }
        //reflection clon if need 
        public virtual void ValidateAggregate()
        {
        }
        protected TEntity CreateShallowCopy() => (TEntity)MemberwiseClone();
        protected void ValidateNotNull(params DomainEntity[] domainEntities)
        {
            _ = domainEntities ?? throw new ArgumentNullException(nameof(domainEntities));
            if (domainEntities.Any(e => e is null))
            {
                throw new NullReferenceException($"One or more required child entities for aggregate of type '{typeof(TEntity).Name}' was null.");
            }
        }
       
    }
}
