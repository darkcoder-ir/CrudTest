using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Mc2.CrudTest.Core.Domain.Abstracation.Models;

namespace Mc2.CrudTest.Core.Domain.ValueObjects
{
    public sealed class Email : ValueObject
    {
        public const int MaxLength = 256;

        private const string EmailRegexPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
        private static readonly Lazy<Regex> EmailFormatRegex =
            new Lazy<Regex>(() => new Regex(EmailRegexPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase));
        private Email(string value) => Value = value;
        public string Value { get; }

        public static implicit operator string(Email email) => email.Value;

        public static Email Create(string email)
        {
            CheckValueObject(email);
            return new Email(email);
        }

        public override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }

        private static void CheckValueObject(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) throw new Exception("");
            if (email.Length > MaxLength) throw new Exception();
            if (!EmailFormatRegex.Value.IsMatch(email)) throw new Exception();

        }
    }
}
