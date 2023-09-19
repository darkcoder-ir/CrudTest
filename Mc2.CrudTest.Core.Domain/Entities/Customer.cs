using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Domain.Entities
{
    public class Customer
    {

        public Customer(string firstname, string lastname, DateTime dateOfBirth, string myProperty)
        {
            Firstname = firstname;
            Lastname = lastname;
            DateOfBirth = dateOfBirth;
            MyProperty = myProperty;
        }

        public string Firstname { get; private set; }
        public string Lastname { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public string MyProperty { get; private set; }
    }
}
