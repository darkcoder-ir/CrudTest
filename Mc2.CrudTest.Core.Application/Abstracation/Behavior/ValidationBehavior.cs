using FluentValidation;
using Mc2.CrudTest.Core.Domain.Core.Exceptions;
using Mc2.CrudTest.Core.Domain.Core.Validations;
using MediatR;

namespace Mc2.CrudTest.Core.Application.Abstracation.Behavior;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
{
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        //pre
        var context = new ValidationContext<TRequest>(request);
        var validationFails = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context)));

        var errors = validationFails.Where(rtesult => !rtesult.IsValid)
            .SelectMany(rtesult => rtesult.Errors)
            .Select(validationFailer =>
                new ValidationError(validationFailer.PropertyName, validationFailer.ErrorMessage))
            .ToList();
        if (errors.Any())
        {
            //or return GenericResponse<ValidationError>
            CustomerValidateException.Throw(errors);
        }

        var Response = await next();

        //post

        return Response;
    }
}