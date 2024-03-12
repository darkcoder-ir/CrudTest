using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mc2.CrudTest.Core.Domain.Abstracation.Models;

namespace Mc2.CrudTest.Core.Domain.ValueObjects
{
    public sealed class DateOfBirth : ValueObject
    {
        public string Value { get; }

        protected DateOfBirth(DateTime dateOfBirth)
        {
            // Validate that the date of birth is within an acceptable range (e.g., 100 years ago from today)
            CheckValueObject(dateOfBirth);

            Value = dateOfBirth.ToShortDateString();
        }

        protected DateOfBirth()
        {

        }

        private static void CheckValueObject(DateTime dateOfBirth)
        {
            DateTime minDateOfBirth = DateTime.Today.AddYears(-100);
            DateTime maxDateOfBirth = DateTime.Today.AddYears(-16);

            if (dateOfBirth < minDateOfBirth || dateOfBirth > maxDateOfBirth)
            {
                throw new ArgumentOutOfRangeException(nameof(dateOfBirth), "Date of birth must be within the last 90 years.");
            }
        }

        public static DateOfBirth Create(DateTime BirthDate)
        {
            return new DateOfBirth(BirthDate);
        }
        public override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
        public static implicit operator string(DateOfBirth DateOfBirth) => DateOfBirth.Value;
    }
}
