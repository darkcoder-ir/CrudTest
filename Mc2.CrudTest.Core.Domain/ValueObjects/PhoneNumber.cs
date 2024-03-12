using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Core.Domain.Abstracation.Models;

namespace Mc2.CrudTest.Core.Domain.ValueObjects
{
    public sealed class PhoneNumber : ValueObject
    {
        public const int MaxLength = 11;
        private PhoneNumber(ulong value) => Value = value;
        public ulong Value { get; }

        public static PhoneNumber Create(ulong phonenimber)
        {
            CheckValueObject(phonenimber);
            return new PhoneNumber(phonenimber);
        }

        private static void CheckValueObject(ulong phonenimber)
        {
            //  Being Uniqe is Checked in Application Layer because of IO bounding need and Extra Library must be in infrastructure
            // maybe somebody tolds you could Check uinqing that in event List in Customers Aggregate but that wasnt correct way because maybe some other 
            //web services Adding this Entity ! (By  Condition this id Base Entity and Used in Any Aggregate root)
            //or maybe i create some customer that is in event  store first, and after savechanges they will be clears and after that there isnt state of created customer befor in Aggregate Events...

        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
