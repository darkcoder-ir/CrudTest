using Mc2.CrudTest.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Core.Domain.Abstracation.Models;
using Mc2.CrudTest.Core.Domain.Resources;
using Mc2.CrudTest.Core.Domain.ValueObjects;

namespace Mc2.CrudTest.Core.Domain.Entities;

public sealed class Customer : DomainEntity<Customer> , IAggregateRoot
{
    public  Customer _customer;


    public FirstName FirstName { get; private set; }

    public LastName LastName { get; private set; }

    public Email Email { get; private set; }
    public AccountNumber AccountNumber { get; private set; }
    public DateOfBirth DateOfBirth { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    

    public Customer(FirstName firstName, LastName lastName, Email email, PhoneNumber phoneNumber,
        AccountNumber accountNumber, DateOfBirth dateOfBirth) : base(Guid.NewGuid())
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        AccountNumber = accountNumber;
        DateOfBirth = dateOfBirth;
        PhoneNumber = phoneNumber;
        _customer = this;
    }


    public static Customer Create(FirstName firstName, LastName lastName, Email email, PhoneNumber phoneNumber,
        AccountNumber accountNumber, DateOfBirth dateOfBirth)
    {
        var _customer = new Customer(firstName, lastName, email, phoneNumber, accountNumber, dateOfBirth);
        _customer.AddDomainEvent(new CustomerCreatedEvent(_customer));
        return _customer;
    }
}