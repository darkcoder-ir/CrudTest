using Mc2.CrudTest.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Domain.Entities
{
    public sealed class Customer : DomainEntity
    {

        public Customer(Guid Id ,string firstname, string lastname, DateTime dateOfBirth, ulong phoneNumber, string email, string bankAccountNumber)
        {
            Id = Id;
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            Email = email;
            BankAccountNumber = bankAccountNumber;
        }

        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public ulong PhoneNumber { get; private set; }
        public string Email { get; private set; }
        public string BankAccountNumber { get; private set; }
    }
}
