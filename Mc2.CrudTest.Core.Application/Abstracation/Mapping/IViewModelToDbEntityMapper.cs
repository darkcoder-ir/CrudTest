using Mc2.CrudTest.Core.Application.Abstracation.DbContext;
using Mc2.CrudTest.Core.Application.Customer;
using Mc2.CrudTest.Core.Application.Models;
using Mc2.CrudTest.Core.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Core.Application.Abstracation.Mapping
{
    public interface IViewModelToDbEntityMapper<TViewModel, TDbEntity> where TViewModel : IViewModel where TDbEntity : IDbEntity
    {
        TDbEntity Map(TViewModel source);

        void Map(TViewModel source, TDbEntity destination);
    }
    public static class ViewModelToDbEntityMapper
    {

        public static CustomerEntity customerMap(CustomerViewModel customerViewModel)
        {

            return new CustomerEntity
            {
                FirstName = FirstName.Create(customerViewModel.FirstName).ToString(),
                LastName = LastName.Create(customerViewModel.LastName).ToString(),
                DateOfBirth = customerViewModel.DateOfBirth, // we could use same way to create value object and validate
                PhoneNumber = customerViewModel.PhoneNumber, // we must using google validate that it should be infrastructure layer or validating in domain layer and i should check phone numbers start with 00 if i using ulong // i want to use nvarchar(14) with create fluentApi Config 
                BankAccountNumber = customerViewModel.BankAccountNumber,
                Email = customerViewModel.Email,
            };
        }
    }

}
