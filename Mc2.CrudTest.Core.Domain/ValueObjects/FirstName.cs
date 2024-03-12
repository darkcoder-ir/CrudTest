using Mc2.CrudTest.Core.Domain.Abstracation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Domain.ValueObjects
{
    public sealed class FirstName : ValueObject
    {
        public const int MaxLenght = 50;
        public string Value { get; }
        public static implicit operator string(FirstName firstName) => firstName.Value;

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        private FirstName(string value)
        {
            Value = value;
        }
        public static FirstName Create(string firstName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException(nameof(firstName), "firstName is null or Empty");
            if (firstName.Length > MaxLenght)
                throw new ArgumentNullException(nameof(firstName), "FirstName is too long");
            return new FirstName(firstName);
        }
        public override string ToString()
        {
            return Value;
        }
    }
}
