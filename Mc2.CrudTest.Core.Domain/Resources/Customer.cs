using Mc2.CrudTest.Core.Domain.Models;
using Mc2.CrudTest.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Domain.Resources
{
    public class Customer : DomainEntity<Customer>
    {
        public FirstName Firstname { get; init; }
        public LastName Lastname { get; init; }
        public DateTime DateOfBirth { get; init  ; }
        public ulong PhoneNumber { get; init  ; }  // it should better if i create mobile number value object but in the readme tolds using nvarchar or ulong
        public string Email { get; init  ; }
        public string BankAccountNumber { get; init  ; }
        public void CreateCustomerEvent() => AddDomainEvent(new CustomerCreatedEvent(this));
        public void UpdateCustomerEvent() => AddDomainEvent(new CustomerUpdatedEvent(this));
        public override void ValidateAggregate()
        {
            //validate mobile number by external lib in upper layer
            //throw exeption if not valid
        }
    }
}
