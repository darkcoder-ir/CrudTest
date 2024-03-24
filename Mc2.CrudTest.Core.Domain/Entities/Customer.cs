using Mc2.CrudTest.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Core.Domain.Abstracation.Models;
using Mc2.CrudTest.Core.Domain.Entities.Events;
using Mc2.CrudTest.Core.Domain.ValueObjects;

namespace Mc2.CrudTest.Core.Domain.Entities;

public sealed class Customer : DomainEntity<Customer>, IAggregateRoot , AuditableDbEntity
{
    private Customer() : base()
    {
    }

    public Customer _customer;


    public FirstName FirstName { get; private set; }

    public LastName LastName { get; private set; }

    public Email Email { get; private set; }
    public AccountNumber AccountNumber { get; private set; }
    public DateOfBirth DateOfBirth { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }

    //public bool IsDeleted { get; }
    private Customer(FirstName firstName, LastName lastName, Email email, PhoneNumber phoneNumber,
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
        var customer = new Customer(firstName, lastName, email, phoneNumber, accountNumber, dateOfBirth);
            customer.AddDomainEvent(new CustomerCreatedEvent(customer));
        return customer;
    }
    public static Customer Create(string firstName, string lastName, string email, string phoneNumber,
        string accountNumber, string dateOfBirth)
    {
        var customer = new Customer(FirstName.Create(firstName), LastName.Create(lastName),
            Email.Create(email)
            , PhoneNumber.Create(ulong.Parse(phoneNumber))
            , AccountNumber.Create(accountNumber),
            DateOfBirth.Create(DateTime.Parse(dateOfBirth)));
        //Note!!!

        customer.AddDomainEvent(new CustomerCreatedEvent(customer));
        return customer;
        
    }

    public string CreatedBy { get; set; }
    public DateTime CreatedUtc { get; set; }
    public string? LastModifiedBy { get; set; }
    public DateTime? LastModifiedUtc { get; set; }
}