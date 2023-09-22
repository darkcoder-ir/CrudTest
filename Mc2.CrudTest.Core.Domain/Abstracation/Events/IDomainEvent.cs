﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Domain.Abstracation.Events
{
    public interface IDomainEvent : INotification
    { 
        DateTime DateTimeOccurredUtc { get; }
    }
}
