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
        public TEntity CloneWith(Action<TEntity> action)   // for the scenarios that we wants to with void deligate or func or Action
                                                           // combine one Aggregate to Another And Geting that ready for
                                                           // setuping Aggregate Root. not usseage in this scenario
        {
            var e = CreateShallowCopy();
            action(e);
            return e;
        }


        public virtual void ValidateAggregate()
        {
        }
        //reflection clon if need 
        protected TEntity CreateShallowCopy() => (TEntity)MemberwiseClone();

        protected void ValidateNotNull(params DomainEntity[] domainEntities)
        {
           
            if (domainEntities.Any(e => e is null))
            {
                throw new NullReferenceException($"One or more required child entities for aggregate of type '{typeof(TEntity).Name}' was null.");
            }
        }

        /// <inheritdoc />
        protected DomainEntity(Guid Id) : base(Id)
        {
        }
    }
}
