using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Mc2.CrudTest.Core.Application.Customer.Command.CreateCustomer;
using PhoneNumbers;

namespace Mc2.CrudTest.Core.Application.Abstracation.Behavior
{
    public class CreateUpdateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {

        public CreateUpdateCustomerValidator(ICustomerService)
        {
            RuleFor(f => f.Customer.PhoneNumber).MustAsync(ValidatePhoneNumber)
                .WithMessage("Phone number is not local valid mobile number");

        }
        private async Task<bool> ValidatePhoneNumber(string arg1, CancellationToken token)
        {
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
