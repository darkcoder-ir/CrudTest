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
        DataError = (List<ValidationError>)info.GetValue("DataError", typeof(List<ValidationError>));
    }

    public static CustomerValidateException @Throw(List<ValidationError> errors)
    {
        return new CustomerValidateException(errors);
    }

    public List<ValidationError> GetErrors()
    {
        return DataError;
    }
    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        base.GetObjectData(info, context);

        // Serialize the DataError list by adding it to the SerializationInfo object
        info.AddValue("DataError", DataError, typeof(List<ValidationError>));
    }
}