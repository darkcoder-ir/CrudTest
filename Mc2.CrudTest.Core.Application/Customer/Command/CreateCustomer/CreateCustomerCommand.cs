using AutoMapper;
using MediatR;
using Mc2.CrudTest.Core.Application.Abstracation.NewRepositoryPattern;
using Mc2.CrudTest.Core.Application.Services;
using Mc2.CrudTest.Core.Domain.Core.Exceptions;
using Mc2.CrudTest.Core.Domain.Models;


namespace Mc2.CrudTest.Core.Application.Customer.Command.CreateCustomer ;

  public class CreateCustomerCommand : IRequest<Response>
  {
    public CustomerViewModel? Customer { get; set; }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response>
    {
      public CreateCustomerCommandHandler
              (
              IWriteCustomerRepository repository,  ICustomerService iCustomerService,
              IDbContext dbContext)
        {
          _repository = repository;
          _iCustomerService = iCustomerService;
          _dbContext = dbContext;
     
        }


      private readonly IWriteCustomerRepository _repository;
      private readonly IMapper _mapper;
      private readonly ICustomerService _iCustomerService;
      private readonly IDbContext _dbContext;
      private Response _response ;

      public async Task<Response> Handle
              (
              CreateCustomerCommand request,
              CancellationToken cancellationToken)
        {
          Domain.Entities.Customer customerEntityMapped;
          if ( request == null ) throw new ArgumentNullException ($"request is Null...");
          {
            var entityMapped = request.Customer ?? throw new ArgumentNullException (nameof (Customer));
                                       customerEntityMapped = Domain.Entities.Customer.Create (entityMapped.FirstName,
                                                                                               entityMapped.LastName,
                                                                                               entityMapped.Email,
                                                                                               entityMapped.PhoneNumber,
                                                                                               entityMapped.BankAccountNumber,
                                                                                               entityMapped.DateOfBirth
                                                                      );
          }
          // var ebitymaped = _mapper.Map<Domain.Entities.Customer>(request.Customer);
          var commandType = await _iCustomerService.GetCommandType ();
          await using ( var trans = await _dbContext.datbase.BeginTransactionAsync (cancellationToken) )
          {
            try
            {
              if ( string.Equals (commandType, Enum.GetName (CommandTypeEnum.Update),
                                  StringComparison.CurrentCultureIgnoreCase) ) // one of this check is enoph 
              {
                // this is not nessecary to using clone way... because i was handling event part in domain creating moment just in Unit save changes i will publish event // Actulyy i was impiliment stronger domain with dispachers event (more event with some speacial event) that wasnt need only one event publishing (means to event storing) was inophe
                // customerEntityMapped.AddDomainEvent(new CustomerUpdatedEvent(customerEntityMapped.CloneWith(""""""""""""""""""));
                // Update.
                // this was good for know Add or Update ...
                //that header was nor nessecary just i must attention Customer Guid when i want to create that.

                var result = await _repository.UpdateAsync (customerEntityMapped);
                _response = Response.Create (202, "Customer Updated", true) ?? throw new NullReferenceException();
              }
              else
              {
                var result = await _repository.AddAsync (customerEntityMapped);
                _response = Response.Create (201, "Customer Created", true) ?? throw new NullReferenceException();
                }

              await trans.CommitAsync (cancellationToken);
            }
            catch ( Exception e )
            {
              await trans.RollbackAsync (cancellationToken);
              throw new CustomNotResultException (NotResultTypeEnum.InternalFail);
            }
          }

          return _response;
        }
    }
  }

  public enum CommandTypeEnum
  {
    Update = 1,
    Insert = 2
  }