using Mc2.CrudTest.Core.Domain.Abstracation.Events;
using Mc2.CrudTest.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Domain.Events
{
    public abstract class DomainEvent : IDomainEvent
    {
        private static IDateTimeService dateTimeService = new NullDateTimeService();

        public DateTime DateTimeOccurredUtc { get; }

        protected DomainEvent() => DateTimeOccurredUtc = dateTimeService.UtcNow;

        internal static void WireUpDateTimeService(IDateTimeService dateTimeService) => DomainEvent.dateTimeService = dateTimeService;

    }
}
