using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Application.Models
{
    public abstract class AuditableDbEntity : IDbEntity
    {
        public string CreatedBy { get; set; } = default!;

        public DateTime CreatedUtc { get; set; }

        public string? LastModifiedBy { get; set; }

        public DateTime? LastModifiedUtc { get; set; }
    }
}
