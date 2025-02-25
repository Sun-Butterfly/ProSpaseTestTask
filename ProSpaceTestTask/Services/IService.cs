namespace ProSpaceTestTask.Services;

public interface IService
{
    string GenerateCustomerCode();
    int GetRoleId();
    string GenerateItemCode();
    Task<long> GetOrderNumber(Guid customerId, CancellationToken cancellationToken);
}