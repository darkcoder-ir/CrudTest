using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Core.Domain.Abstracation.Models;

namespace Mc2.CrudTest.Core.Domain.ValueObjects
{
    public sealed class AccountNumber : ValueObject

    {
        private AccountNumber(string value) => Value = value;
        public string Value { get; }

        public static AccountNumber Create(string accountNumber)
        {
            CheckValueObject(accountNumber);
            return new AccountNumber(accountNumber);
        }

        private static void CheckValueObject(string accountNumber)
        {
            // that will be validating in front end before Submiting form By accourding a task
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}
