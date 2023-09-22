using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Domain.Common
{
    public class NullDateTimeService : IDateTimeService
    {
        public DateTime UtcNow => new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    }
}
