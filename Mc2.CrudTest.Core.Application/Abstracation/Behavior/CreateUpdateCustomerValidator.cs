using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Mc2.CrudTest.Core.Application.Customer;
using Mc2.CrudTest.Core.Application.Customer.Command.CreateCustomer;
using Mc2.CrudTest.Core.Application.Services;
using PhoneNumbers;

namespace Mc2.CrudTest.Core.Application.Abstracation.Behavior
{
    public class CreateUpdateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        private readonly IValidateService _validateService;

        public CreateUpdateCustomerValidator(IValidateService validateService)
        {
            _validateService = validateService;
            RuleFor(f => f.Customer!.PhoneNumber).MustAsync(ValidatePhoneNumber)
                .WithMessage("Phone number is not local valid mobile number");
            RuleFor(w => w.Customer).MustAsync(ValidateFullname)
                .WithMessage("FirstName and LastName and DateBirth Duplicated");
            RuleFor(f => f.Customer.Email).MustAsync(ValidateEmailUniqe)
                .WithMessage("Email must be Uniq in Database");
        }

        private async Task<bool> ValidateEmailUniqe(string email, CancellationToken arg2)
        {
            var res = await _validateService.CheckCustomerExsistByEmail(email);
            return res;
        }

        private async Task<bool> ValidateFullname(CustomerViewModel arg1, CancellationToken arg2)
        {
            var exists =await
                _validateService.CheckCustomerExsistByFullName(arg1.FirstName, arg1.LastName, arg1.DateOfBirth);
                return exists;
        }

        private async Task<bool> ValidatePhoneNumber(string? arg1, CancellationToken token)
        {
                if ( arg1 == null ) throw new ArgumentNullException (nameof (arg1));
                PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();
            try
            
            {
                var result = await Task.Run(() => phoneNumberUtil.IsPossibleNumber(arg1.ToString(), "IR"));

                return result;
            }
            catch
            {
                return false;
            }
        }
    }
}
