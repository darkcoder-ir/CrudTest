using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Domain.Core.Exceptions
{
    [Serializable]
    public sealed class CustomNotResultException : Exception
    {
        public NotResultTypeEnum Type { get; set; }

        public CustomNotResultException(NotResultTypeEnum type)
        {
            Type = type;
        }
        protected CustomNotResultException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }


    }
    public enum NotResultTypeEnum
    {
        Duplicated,
        NotExsistByFirstLastBirth,
        NotAnyCustomer,
        NotCustomerByEmail,
        NotExsist

    }
}
