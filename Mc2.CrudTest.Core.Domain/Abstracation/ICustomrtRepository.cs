using Mc2.CrudTest.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Domain.Abstracation
{
    public interface ICustomrtRepository
    {
        void insert(Customer customer);
    }
}
