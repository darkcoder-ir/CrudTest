namespace Mc2.CrudTest.Core.Application.Customer.Command.CreateCustomer
{
    //public sealed class CreateCustomerCommandHandler :ICommandHandler<CreateCustomerCommand , Guid>
    //{
    //    private readonly ICustomrtRepository _customrtRepository;
    //    private readonly IUnitOfWorks _unitOfWorks ;
    //    public async Task<Guid> Handle (CreateCustomerCommand request ,CancellationToken cancellationToken)
    //    {
    //        var Customer = new Mc2.CrudTest.Core.Domain.Entities.Customer(Guid.NewGuid () , request.FirstName , request.LastName , request.DateOfBrith ,request.PhoneNumber,request.Email , request.BankAccountNumber);
    //    _customrtRepository.insert(Customer);
    //        await _unitOfWorks.SaveChangesAsync(cancellationToken);
    //        return Customer.Id;
    //    }
    //}
}
