using Mc2.CrudTest.Core.Domain.Abstracation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Domain.ValueObjects
{
    public sealed class LastName : ValueObject
    {
        public const int MaxLenght = 50;
        public string Value { get; }


        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        private LastName(string value)
        {
            Value = value;
        }
        public static LastName Create(string LastName)
        {
            if (string.IsNullOrEmpty(LastName))
                throw new ArgumentNullException(nameof(LastName), "LastName is null or Empty");
            if (LastName.Length > MaxLenght)
                throw new ArgumentNullException(nameof(LastName), "LastName is too long");
            return new LastName(LastName);
        }
        public override string ToString()
        {
            return Value;
        }
    }
}
