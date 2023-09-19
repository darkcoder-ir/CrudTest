using Mc2.CrudTest.Core.Domain.Abstracation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Domain.Common.Users
{
    public record Customer(string Firstname, string Lastname, DateTime DateOfBirth, ulong PhoneNumber, string Email, string BankAccountNumber) : IValueObject
    {
        public override string ToString()
        {
            string mobilenumber = string.Format(("00000000000", PhoneNumber).ToString());
            return mobilenumber;
        }
    }
}
