﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Domain.Common
{
    public interface IDateTimeService
    {
        DateTime UtcNow { get; }
    }
}
