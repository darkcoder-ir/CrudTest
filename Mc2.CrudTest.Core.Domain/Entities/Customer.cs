using Mc2.CrudTest.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Core.Domain.Abstracation.Models;
using Mc2.CrudTest.Core.Domain.Entities.Events;
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
        //Note!!!
        //One think is bad is this :  i work on this project after couple dayes distance between them so iwill forgot what i was done what i was thinking what i did ant not completed
        /// for example i was using inside rising pattern to automating rising and i was forget that tonight and i west a 1 hour time to creating event Abstaacted in domain
        /// and genericing in UseCase layer ... after i wanted to see my domain clone name i figgured out that i was impilimented that 3 nights ago in another pattern
        /// and i had to get back my impiliment Actuly Re impiliuments that because Undoing with gitchanges for reason of 'didnt following one of standard git coding methology' , would not be safe to undo , because i didnt create any branch for evry feat and bugs or errors...
        /// i wouldnt think that takes that much too long otherwise i would following standard discription
        /// SO REIMPILIMENT :((
        _customer.AddDomainEvent(new CustomerCreatedEvent(_customer));
        return _customer;
    }
}