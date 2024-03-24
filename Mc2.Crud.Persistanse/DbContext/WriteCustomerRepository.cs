

using Mc2.CrudTest.Core.Application.Abstracation.NewRepositoryPattern;
using Mc2.CrudTest.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Mc2.Crud.Persistanse.DbContext
{
    public class WriteCustomerRepository : IWriteCustomerRepository 
    {
        private readonly MyAppContext _myAppContext;

        public WriteCustomerRepository(MyAppContext myAppContext)
        {
            _myAppContext = myAppContext;

        }
        public async Task<int> SaveChangesAsync(CrudTest.Core.Domain.Entities.Customer entity)
        {


            await Task.WhenAll(entity.DispatchDomainEventsAsync());

            return await _myAppContext.SaveChangesAsync();
        }

        public async Task<int> AddAsync(Customer entity)
        {

            _myAppContext.Add(entity);
            return await SaveChangesAsync(entity);

        }

        public async Task<int> UpdateAsync(Customer entity)
        {

            var old =await  _myAppContext.Customers.Where(w => w.FirstName == entity.FirstName &&
                                                         w.LastName == entity.LastName &&
                                                         w.DateOfBirth == entity.DateOfBirth).SingleAsync();

            _myAppContext.Entry(old).CurrentValues.SetValues(entity);


            return await SaveChangesAsync(entity);

        }

        public async Task DeleteAsync(Customer entity)
        {
            throw new NotImplementedException();
        }


    }
}
