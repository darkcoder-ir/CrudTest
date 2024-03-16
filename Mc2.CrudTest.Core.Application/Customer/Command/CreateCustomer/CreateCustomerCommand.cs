using System.Transactions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mc2.CrudTest.Core.Application.Abstracation.NewRepositoryPattern;
using Mc2.CrudTest.Core.Domain;
using Mc2.CrudTest.Core.Domain.Core.Exceptions;
using Mc2.CrudTest.Core.Domain.Entities.Events;
using Mc2.CrudTest.Core.Domain.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace Mc2.CrudTest.Core.Application.Customer.Command.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Response>
    {
        public CustomerViewModel Customer { get; set; } 

        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response>
        {
            public CreateCustomerCommandHandler(IWriteCustomerRepository IRepository, IMapper mapper, ICustomerService iCustomerService , IDbContext dbContext)
            {
                _repository = IRepository;
                _mapper = mapper;
               _iCustomerService = iCustomerService ;
               _dbContext = dbContext;
            }


            private readonly IWriteCustomerRepository _repository;
            private readonly IMapper _mapper;
            private readonly ICustomerService _iCustomerService;
            private readonly IDbContext _dbContext;
            private Response _response;

            public async Task<Response> Handle(CreateCustomerCommand request,
                CancellationToken cancellationToken)
            {
                Domain.Entities.Customer customerEntityMapped;
                if (request == null) throw new ArgumentNullException(nameof(request.Customer)); 
                {
                   customerEntityMapped = Domain.Entities.Customer.Create(request.Customer.FirstName,
                        request.Customer.LastName
                        , request.Customer.Email, request.Customer.PhoneNumber, request.Customer.BankAccountNumber,
                        request.Customer.DateOfBirth
                    );
                }
               // var ebitymaped = _mapper.Map<Domain.Entities.Customer>(request.Customer);
           
                var commandType = await _iCustomerService.GetCommandType();
                using (var trans = _dbContext.datbase.BeginTransaction() )
                {

                    try
                    {
                        
                        if (commandType == CommandTypeEnum.update.ToString()) // one of this check is enoph 
                        {
                            // this is not nessecary to using clone way... because i was handling event part in domain creating moment just in Unit save changes i will publish event // Actulyy i was impiliment stronger domain with dispachers event (more event with some speacial event) that wasnt need only one event publishing (means to event storing) was inophe
                           // customerEntityMapped.AddDomainEvent(new CustomerUpdatedEvent(customerEntityMapped.CloneWith(""""""""""""""""""));
                            // Update.
                            // this was good for know Add or Update ...
                            //that header was nor nessecary just i must attention Customer Guid when i want to create that.

                            var result =await _repository.UpdateAsync(customerEntityMapped);
                            _response =  Response.Create(202, "Customer Updated", true);
                        }
                        else
                        {
                         var result =  await _repository.AddAsync(customerEntityMapped);
                            _response =  Response.Create(201, "Customer Created", true);
                        }

                        trans.CommitAsync();


                    }
                    catch (Exception e)
                    {
                        trans.RollbackAsync();
                     throw new   CustomNotResultException(NotResultTypeEnum.InternalFail);
                    }
                }
                
                return _response;
            }
        }
    }

    public enum CommandTypeEnum
    {
        update =1 ,
        insert =2
    }
  
}