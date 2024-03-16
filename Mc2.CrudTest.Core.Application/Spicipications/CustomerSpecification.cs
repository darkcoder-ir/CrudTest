using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Specification;
using Mc2.CrudTest.Core.Domain.ValueObjects;

namespace Mc2.CrudTest.Core.Application.Spicipications
{
    public sealed class CustomerSpecification : Specification<Domain.Entities.Customer>
    {

        public CustomerSpecification(string Email)
        {
            Query.Where(c=>c.Email.Value==Email);
        }
        public CustomerSpecification(Guid Id)
        {
            Query.Where(w=>w.Id==Id);
        }
    }
}
