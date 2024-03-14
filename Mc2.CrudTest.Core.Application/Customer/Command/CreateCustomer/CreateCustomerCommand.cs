using System.Transactions;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Mc2.CrudTest.Core.Application.Abstracation.NewRepositoryPattern;
using Mc2.CrudTest.Core.Domain.Core.Exceptions;
using Mc2.CrudTest.Core.Domain.Entities.Events;
using Mc2.CrudTest.Core.Domain.Models;


namespace Mc2.CrudTest.Core.Application.Customer.Command.CreateCustomer
{
    public class CreateCustomerCommand : IRequest<Response>
    {
        public CustomerViewModel Customer { get; init; } = default!;

        public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Response>
        {
            public CreateCustomerCommandHandler(IRepository<Domain.Entities.Customer> IRepository, IMapper mapper)
            {
                _repository = IRepository;
                _mapper = mapper;
            }

            private readonly IRepository<Domain.Entities.Customer> _repository;
            private readonly IMapper _mapper;
            private readonly ICustomerService _iCustomerService;
            private Response _response;

            public async Task<Response> Handle(CreateCustomerCommand request,
                CancellationToken cancellationToken)
            {
                var commandType = await _iCustomerService.GetCommandType();
                var CurrentCustomer = await _repository.GetByIdAsync(request.Customer.ViewModelId);
                using (var ts = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        var customerEntityMapped = _mapper.Map<Domain.Entities.Customer>(request.Customer.ViewModelId);
                        if (commandType == CommandTypeEnum.update.ToString() ||
                            CurrentCustomer != null) // one of this check is enoph 
                        {
                            customerEntityMapped.AddDomainEvent(new CustomerUpdatedEvent(customerEntityMapped.c));
                            // Update.
                            // this was good for know Add or Update ...
                            //that header was nor nessecary just i must attention Customer Guid when i want to create that.

                            await _repository.UpdateAsync(customerEntityMapped);
                            _response = await Response.Create(202, "Customer Updated", true);
                        }
                        else
                        {
                            await _repository.AddAsync(customerEntityMapped);
                            _response = await Response.Create(201, "Customer Created", true);
                        }

                        await _repository.SaveChangesAsync();
                        ts.Complete();
                    }
                    catch (Exception e)
                    {
                        CustomNotResultException.Throw(NotResultTypeEnum.InternalFail);
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