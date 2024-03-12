using System.Runtime.Serialization;
using Mc2.CrudTest.Core.Domain.Core.Validations;

namespace Mc2.CrudTest.Core.Domain.Core.Exceptions;

[Serializable]
public sealed class CustomerValidateException : Exception
{
    private List<ValidationError> DataError{ get; }

    private CustomerValidateException(List<ValidationError> errors)
    {
        DataError = errors;
    }

    protected CustomerValidateException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public static CustomerValidateException @Throw(List<ValidationError> errors)
    {
        return new CustomerValidateException(errors);
    }

    public List<ValidationError> GetErrors()
    {
        return DataError;
    }
}